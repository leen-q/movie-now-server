using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using MySqlConnector;
using System.Data;

namespace MovieNowAPI.MachineLearning
{
    public class ModelTrainer
    {
        MLContext mlContext = new MLContext();

        public async Task TrainModel()
        {
            IDataView dataView = LoadData(mlContext);
            ITransformer model = BuildAndTrainModel(mlContext, dataView);
            SaveModel(mlContext, dataView.Schema, model);
        }

        IDataView LoadData(MLContext mlContext)
        {

            DatabaseLoader loader = mlContext.Data.CreateDatabaseLoader<MovieRating>();

            string connectionString = @"Server=localhost;User ID=root;Password=Zhenya2002VerB123_;Port=3306;Database=movienowdb";

            string sqlCommand = "select cast(userId as FLOAT) as userId, cast(movieId as FLOAT) as movieId, cast(ratingNumber as FLOAT) as Label from ratings";

            DatabaseSource dbSource = new DatabaseSource(MySqlConnectorFactory.Instance, connectionString, sqlCommand);

            IDataView dataView = loader.Load(dbSource);

            return dataView;
        }

        ITransformer BuildAndTrainModel(MLContext mlContext, IDataView dataView)
        {
            IEstimator<ITransformer> estimator = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: "userId")
            .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "movieIdEncoded", inputColumnName: "movieId"));

            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "userIdEncoded",
                MatrixRowIndexColumnName = "movieIdEncoded",
                LabelColumnName = "Label",
                NumberOfIterations = 30,
                ApproximationRank = 128,
                LearningRate = 0.1
            };

            var trainerEstimator = estimator.Append(mlContext.Recommendation().Trainers.MatrixFactorization(options));

            var crossValidationResults = mlContext.Recommendation().CrossValidate(dataView,
                                                                                  trainerEstimator,
                                                                                  numberOfFolds: 5,
                                                                                  labelColumnName: "Label");

            var averageRMSE = crossValidationResults.Select(x => x.Metrics.RootMeanSquaredError).Average();
            var averageRSquared = crossValidationResults.Select(x => x.Metrics.RSquared).Average();

            var bestModel = crossValidationResults
                            .OrderByDescending(x => x.Metrics.RSquared)
                            .FirstOrDefault()
                            .Model;

            return bestModel;
        }

        void SaveModel(MLContext mlContext, DataViewSchema dataViewSchema, ITransformer model)
        {
            var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "MovieRecommenderModel.zip");

            mlContext.Model.Save(model, dataViewSchema, modelPath);
        }
    }
}
