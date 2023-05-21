using Business.Commands.Category;
using Business.Commands.Product;
using Business.Commands.Role;
using Business.Commands.User;
using Business.Interfaces;
using Business.Mappings;
using Business.Queries.Category;
using Business.Queries.User;
using Business.Services;
using Dal.Commands.Category;
using Dal.Commands.Product;
using Dal.Commands.Role;
using Dal.Commands.User;
using Dal.Database.Access;
using Dal.Entities;
using Dal.Interfaces;
using Dal.Queries.Category;
using Dal.Queries.User;
using Dal.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Web_api.Extensions;

public static class AllServicesExtension
{
    /// <summary>
    /// Registers all the services, commands, queries and utilities required for the application
    /// </summary>
    /// <param name="service">The <see cref="IServiceCollection"/> to add the services to</param>
    /// <param name="configuration">The configuration for the application</param>
    /// <returns>The updated <see cref="IServiceCollection"/></returns>
    public static IServiceCollection AddAllServices(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<AppDbContext>();

        service.RegisterIdentityService();
        service.RegisterAuthenticationService(configuration);

        service.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(Program).Assembly));

        // repositories
        service.AddScoped<IProductRepository, ProductRepository>();
        service.AddScoped<ICategoryRepository, CategoryRepository>();
        
        // services
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<ITokenService, TokenService>();
        service.AddScoped<IProductService, ProductService>();
        service.AddScoped<ICategoryService, CategoryService>();

        // cqrs commands
        service.AddScoped<IRequestHandler<CreateUserCommand, CreateUserCommandResult>, CreateUserCommandHandler>();
        service.AddScoped<IRequestHandler<CreateRoleCommand, IdentityResult>, CreateRoleCommandHandler>();
        service.AddScoped<IRequestHandler<CreateProductCommand, Product>, CreateProductCommandHandler>();
        service.AddScoped<IRequestHandler<CreateCategoryCommand, Category>, CreateCategoryCommandHandler>();

        // cqrs queries
        service.AddScoped<IRequestHandler<GetAllUsersQuery, IEnumerable<AppUser>>, GetAllUsersHandler>();
        service.AddScoped<IRequestHandler<GetUserByIdQuery, AppUser?>, GetUserByIdHandler>();
        service.AddScoped<IRequestHandler<GetUserByEmailQuery, AppUser?>, GetUserByEmailHandler>();
        service.AddScoped<IRequestHandler<GetUserRoleQuery, IEnumerable<string>>, GetUserRoleHandler>();
        service.AddScoped<IRequestHandler<GetCategoryByNameQuery, Category?>, GetCategoryByNameHandler>();

        // utilities
        service.AddScoped<IAppMapper, AppMapper>();

        return service;
    }
}
