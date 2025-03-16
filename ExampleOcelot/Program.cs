
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ExampleOcelot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Ocelot
            IConfiguration configuration = new ConfigurationBuilder()
             .AddJsonFile("ocelotexample.json").Build();
            builder.Services.AddSwaggerForOcelot(configuration);
            builder.Services.AddOcelot(configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                //Ocelot
                app.UseSwaggerForOcelotUI();
                //app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseOcelot().Wait();

            app.MapControllers();

            app.Run();
        }
    }
}
