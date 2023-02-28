using Chesta.Api;
using Chesta.Application;
using Chesta.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddCors();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseCors(options => {
        options.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
