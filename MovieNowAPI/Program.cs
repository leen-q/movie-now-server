using MovieNowAPI.Entities;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using MovieNowAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEntityFrameworkMySQL().AddDbContext<MovienowDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IFollowerRepository, FollowerRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfilePrivacySettingRepository, ProfilePrivacySettingRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ISystemMessageRepository, SystemMessageRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
