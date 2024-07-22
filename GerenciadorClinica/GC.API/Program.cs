using GC.API.Extensions;
using GC.Application.Extensions;
using GC.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;


namespace GC.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DBClinicaCS");

            #region DEPOIS

            builder.Services.AddGcApplication();
            builder.Services.AddInfrastructure(connectionString);
            builder.Services.AddGcApi();

            #endregion

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
