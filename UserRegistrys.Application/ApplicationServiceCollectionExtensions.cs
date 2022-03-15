
using Microsoft.Extensions.DependencyInjection;
using UserRegistry.Domain.Managers;
using UserRegistrys.Application.Commands;
using UserRegistrys.Application.Queries;
using UserRegistrys.Application.Services;

namespace UserRegistrys.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IUserCRUDOperationService, UserCRUDOperationService>()
                    .AddTransient<GetAllUsersDataQueryHandler>()
                    .AddTransient<PostCreateUserHandler>()
                    .AddTransient<PutUpdateUserHandler>()
                    .AddTransient<DeleteUserHandler>()
                    .AddTransient<GetUserDataQueryHandler>();
            return services;
        }
    }
}
