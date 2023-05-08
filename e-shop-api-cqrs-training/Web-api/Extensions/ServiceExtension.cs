using Business.Commands.Role;
using Business.Commands.User;
using Business.Interfaces;
using Business.Queries.User;
using Business.Services;
using Dal.Commands.Role;
using Dal.Commands.User;
using Dal.Database.Access;
using Dal.Database.Seeds;
using Dal.Entities;
using Dal.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Web_api.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddAllServices(this IServiceCollection service)
    {
        service.AddDbContext<AppDbContext>();
        
        service.AddCustomIdentityConfiguration();
        service.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(Program).Assembly));
        
        service.AddScoped<IUserService, UserService>();

        service.AddScoped<IRequestHandler<CreateUserCommand, CreateUserCommandResult>, CreateUserCommandHandler>();
        service.AddScoped<IRequestHandler<CreateRoleCommand, IdentityResult>, CreateRoleCommandHandler>();

        service.AddScoped<IRequestHandler<GetUsersQuery, IEnumerable<AppUser>>, GetUsersHandler>();
        service.AddScoped<IRequestHandler<GetUserQuery, AppUser>, GetUserHandler>();

        return service;
    }
}
