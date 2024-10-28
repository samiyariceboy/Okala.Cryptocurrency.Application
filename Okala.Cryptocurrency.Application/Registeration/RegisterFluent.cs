using FluentValidation;
using FluentValidation.AspNetCore;

namespace Okala.Cryptocurrency.Application.Registeration
{
    public static class RegisterFluent
    {
        public static void RegisterFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
        }
    }
}
