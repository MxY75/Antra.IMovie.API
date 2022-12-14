using Antra.IMovie.Core.Contracts.Repository;
using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Entity;
using Antra.IMovie.Infrascruture.Data;
using Antra.IMovie.Infrascruture.Repository;
using Antra.IMovie.Infrascruture.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICastRepositorycs, CastRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPurchaseRepostiry, PurchaseRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IMovieCastRepositoryAsync, MovieCastRepositoryAsync>();
builder.Services.AddScoped<IMovieGenreRepositoryAsync, MovieGenreRepositoryAsyn>();
builder.Services.AddScoped<IMovieRepositoryAsync, MovieRepositoryAsync>();
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepositoryAsync>();
builder.Services.AddScoped<ITrailerRepository,TrailerRepository>();

builder.Services.AddScoped<ICookieLoginService, CookieLoginService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ITrailerService, TrailerService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<IMovieServiceAsync, MovieServiceAsync>();
builder.Services.AddScoped<IMovieCastServiceAsync, MovieCastServiceAsync>();
builder.Services.AddScoped<IMovieGenreServiceAsync, MovieGenreService>();
builder.Services.AddScoped<IGenreServiceAsync, GenreServiceAsync>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<ICastService, CastService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountServiceAsync, AccountSerivceAsync>();
builder.Services.AddSqlServer<IMovieCrmDBContext>(builder.Configuration.GetConnectionString("DBIMovie"));
//identity
builder.Services.AddIdentity<AppUser, IdentityRole<int>>().AddEntityFrameworkStores<IMovieCrmDBContext>().AddDefaultTokenProviders();


; builder.Services.AddCors(options => {
    //(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200")
    options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});
//---cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = new PathString("/api/CookieLogin/NoLogin");
});
//--

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{

    x.SaveToken = true;
    x.RequireHttpsMetadata = false;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudiene"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
//--cookie
app.UseCookiePolicy();
//---

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
