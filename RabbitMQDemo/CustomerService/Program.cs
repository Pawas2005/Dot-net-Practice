var builder = WebApplication.CreateBuilder(args);

// Register the RabbitMQ background consumer
builder.Services.AddHostedService<CustomerService.Worker>();

var app = builder.Build();

app.Run();
