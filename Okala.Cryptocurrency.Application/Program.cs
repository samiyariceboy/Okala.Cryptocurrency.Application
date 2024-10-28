using Autofac.Extensions.DependencyInjection;
using Autofac;
using Okala.Cryptocurrency.Application.Registeration;
using Okala.Cryptocurrency.Application.Swagger;
using SeatReserver.Movie.Application.Registeration;
using static Okala.Cryptocurrency.Application.Registeration.AutofacConfigurationExtensions;
using Okala.Cryptocurrency.Domain.Common;
using Okala.Cryptocurrency.Application.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.RegisterFluentValidation();
builder.Services.RegisterMediatR(typeof(IEntity).Assembly, typeof(Program).Assembly);
builder.Services.RegisterApiVersioning();
builder.Services.RegisterCoinMarketCap(builder.Configuration);
builder.Services.RegisterExchangeratesapi(builder.Configuration);

builder.Services.RegisterCustomSwagger(builder.Configuration);


//set autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>
(builder => builder.RegisterModule(new ServiceModules()));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseCustomSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
