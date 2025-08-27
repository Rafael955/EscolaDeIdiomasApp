namespace EscolaDeIdiomasApp.Api.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(
                s => s.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                }));
        }

        public static void UserCorsConfiguration(this IApplicationBuilder app)
        {
            app.UseCors("DefaultPolicy");
        }
    }
}
