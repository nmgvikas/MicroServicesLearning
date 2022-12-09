using Ng.WebApi.MongoDb.RabbitMQ.AppExtensions;
using Ng.WebApi.MongoDb.RabbitMQ.Hubs;
using Ng.WebApi.MongoDb.RabbitMQ.ServiceListeners;
using Ng.WebApi.MongoDb.RabbitMQ.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddSingleton<ICustomerRepositoryService, CustomerRepositoryService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<RabbitMQNewCustomersListener>();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()

);
app.UseAuthorization();
app.UseRabbitMQNewCustomersListener();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<CustomerNotificationHub>("/customerHub");
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
