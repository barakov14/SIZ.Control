using MassTransit;
using Microsoft.EntityFrameworkCore;
using SIZ.NotificationService;


var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});

// Загружаем переменные окружения
var configuration = builder.Configuration;

// Подключаем базу данных
builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

var host = builder.Build();
host.Run();
