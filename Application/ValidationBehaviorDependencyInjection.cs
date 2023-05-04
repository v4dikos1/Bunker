using Application.Pictures.Commands.AddPicture;
using Application.Pictures.Commands.Delete;
using Application.Pictures.Queries.GetPicture;
using Application.Users.Commands.Auth;
using Application.Users.Commands.Delete;
using Application.Users.Commands.Registration;
using Application.Users.Commands.Update;
using Application.Users.Queries.GetUserProfile;
using Application.Users.Queries.GetUsersList;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ValidationBehaviorDependencyInjection
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(RegistrationCommandValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(DeleteUserCommandValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(AuthCommandValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(UpdateUserCommandValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(GetUserProfileQueryValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(GetUsersListQueryValidator));

            services.AddValidatorsFromAssemblyContaining(typeof(AddPictureCommandValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(DeletePictureCommandValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(GetPictureQueryValidator));

            return services;
        }
    }
}
