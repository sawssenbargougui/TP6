using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrdersAPI.Data;
using OrdersAPI.Consumer;
using MassTransit;


var builder = WebApplication.CreateBuilder(args);


// Vérification de la chaîne de connexion (s'assurer qu'elle existe et est correcte)
builder.Services.AddDbContext<OrdersAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrdersAPIContext")
        ?? throw new InvalidOperationException("Connection string 'OrdersAPIContext' not found.")));

// Ajout des services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration de MassTransit
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ProductCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        // Configuration de l'hôte RabbitMQ
        cfg.Host(new Uri("rabbitmq://localhost:4001"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        // Configuration de l'endpoint pour écouter les messages
        cfg.ReceiveEndpoint("event-listener", e =>
        {
            e.ConfigureConsumer<ProductCreatedConsumer>(context);
        });
    });
});


var app = builder.Build();

// Configuration du pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
