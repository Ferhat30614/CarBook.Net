using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.BlogLikeInterfaces;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.Interfaces.CommentLikeInterfaces;
using CarBook.Application.Interfaces.MessageInterfaces;
using CarBook.Application.Interfaces.RentACarIntefaces;
using CarBook.Application.Interfaces.ReviewInterfaces;
using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Application.Service;
using CarBook.Application.Tools;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.BlogLikeRepositories;
using CarBook.Persistence.Repositories.BlogRepositories;
using CarBook.Persistence.Repositories.CarDescriptionRepositories;
using CarBook.Persistence.Repositories.CarFeatureRepositories;
using CarBook.Persistence.Repositories.CarPricingRepositories;
using CarBook.Persistence.Repositories.CarRepositories;
using CarBook.Persistence.Repositories.CommentLikeRepositories;
using CarBook.Persistence.Repositories.CommentRepositories;
using CarBook.Persistence.Repositories.MessageRepositories;
using CarBook.Persistence.Repositories.RentACarRepositories;
using CarBook.Persistence.Repositories.ReviewRepositories;
using CarBook.Persistence.Repositories.StatisticRepositories;
using CarBook.Persistence.Repositories.TagCloudRepositories;
using CarBook.WebApi.Hubs;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>   // CorsPolicy isminde bir cors politikası tanımladık ve kurallarını devamında girdik
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});

builder.Services.AddHttpClient();

builder.Services.AddSignalR();              



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer= JwtTokenDefaults.ValidIssuer,
        ClockSkew=TimeSpan.Zero,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime=true,
        ValidateIssuerSigningKey=true
    };

    //opt.Events = new JwtBearerEvents   // burada acesse erişmek içiin tanımlar var
    //{
    //    OnMessageReceived = context =>
    //    {
    //        var accessToken = context.Request.Cookies["access_token"];
    //        Console.WriteLine("Access Token from Query: " + accessToken);  // Token'ı burada kontrol edelim
    //        var path = context.HttpContext.Request.Path;

    //        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/carhub"))
    //        {
    //            context.Token = accessToken;
    //        }

    //        return Task.CompletedTask;
    //    }
    //};



});

//builder.Services.AddAuthorization();



#region Registiration
// Add services to the container.
builder.Services.AddScoped<CarBookContext>();  //contexti ekledim
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));// IRepository gördüğün yerler Repository dir dedim
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));// ICarRepository gördüğün yerler Repository dir dedim  //bunları olusturuken generic kullanmadımdan burda tanımlarkende gerek yok herhalede
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStatisticRepository), typeof(StatisticRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));
builder.Services.AddScoped(typeof(IBlogLikeRepository), typeof(BlogLikeRepository));
builder.Services.AddScoped(typeof(ICommentLikeRepository), typeof(CommentLikeRepository));
builder.Services.AddScoped(typeof(IMessageRepository), typeof(MessageRepository));



builder.Services.AddScoped<CreateAboutCommandHandler>();//CQRS için configureler 
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();


builder.Services.AddScoped<CreateBannerCommandHandler>();//CQRS için configureler 
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();


builder.Services.AddScoped<CreateBrandCommandHandler>();//CQRS için configureler 
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();


builder.Services.AddScoped<CreateCarCommandHandler>();//CQRS için configureler 
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarWithBrandQueryHandler>();


builder.Services.AddScoped<CreateCategoryCommandHandler>();//CQRS için configureler 
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

builder.Services.AddScoped<CreateContactCommandHandler>();//CQRS için configureler 
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();

builder.Services.AddApplicationService(builder.Configuration);  // mediatr için gerekli configur işlemleri burdan olcak 
#endregion


builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");   // daha önce tanımladımız  bu politikayı uygulayacamızı belirttik
app.UseHttpsRedirection();

app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();

app.MapHub<CarHub>("/carhub");
//CarHub: Bu, SignalR ile ilgili özel bir sınıftır. SignalR, istemcilerle sunucu arasındaki anlık bağlantıyı yöneten sınıf burada CarHub olarak adlandırılmış.
//"/carhub": Hub'ı istemcilerin bağlanabilmesi için belirtilen URL'dir. İstemciler bu URL üzerinden CarHub'a bağlanarak mesaj alabilir ve gönderebilirler.

app.Run();
