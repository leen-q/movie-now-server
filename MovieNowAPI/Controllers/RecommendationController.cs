using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using MovieNowAPI.Entities;
using MovieNowAPI.MachineLearning;
using MovieNowAPI.Repository;
using System.Diagnostics;

namespace MovieNowAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private MLContext mlContext = new MLContext();
        private DataViewSchema modelSchema;

        private IMovieRepository movieRepository;
        private IRatingRepository ratingRepository;

        public RecommendationController(IMovieRepository movieRepository, IRatingRepository ratingRepository)
        {
            this.movieRepository = movieRepository;
            this.ratingRepository = ratingRepository;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Movie>>> GetRecommendationsByUserId(int userId)
        {
            var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "MovieRecommenderModel.zip");
            ITransformer trainedModel = mlContext.Model.Load(modelPath, out modelSchema);
            var predictionEngine = mlContext.Model.CreatePredictionEngine<MovieRating, MovieRatingPrediction>(trainedModel);

            var movies = await movieRepository.GetAllMovies();
            var ratings = await ratingRepository.GetRatingsByUser(userId);
            List<int> ids = ratings.Select(x => x.MovieId).ToList();

            movies.RemoveAll(movie => ids.Contains(movie.Id));

            var recommendations = (from m in movies
                        let p = predictionEngine.Predict(
                           new MovieRating()
                           {
                               userId = userId,
                               movieId = m.Id
                           })
                        orderby p.Score descending
                        select (MovieId: m.Id, Score: p.Score)).Take(3);

            List<Movie> result = new List<Movie>();

            foreach(var r in recommendations)
            {
                Debug.WriteLine($"Score: {r.Score}");
                result.Add(movieRepository.GetMovieById(r.MovieId).Result);
            }

            return result;
        }

        [HttpGet("train")]
        public async Task TrainModel()
        {
            var modelTrainer = new ModelTrainer();
            await modelTrainer.TrainModel();
        }
    }
}
