using MediatR;
using System.Reflection;

namespace SeatReserver.Movie.Application.Registeration
{
    public static class RegisterMediator
    {
        public static void RegisterMediatR(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(assemblies);
                cfg.Lifetime = ServiceLifetime.Transient;
            });
        }
    }
}
