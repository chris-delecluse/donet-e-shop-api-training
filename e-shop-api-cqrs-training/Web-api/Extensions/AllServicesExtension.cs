using Business.Commands.Category;
using Business.Commands.Product;
using Business.Commands.Role;
using Business.Commands.User;
using Business.Interfaces;
using Business.Profiles;
using Business.Queries.Category;
using Business.Queries.Product;
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
using Dal.Queries.Product;
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
        
        service.AddAutoMapper(typeof(Program),
            typeof(ProductProfile),
            typeof(CategoryProfile),
            typeof(StockProfile),
            typeof(UserProfile)
        );

        service.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(Program).Assembly));

        // repositories
        service.AddScoped<IProductRepository, ProductRepository>();
        service.AddScoped<ICategoryRepository, CategoryRepository>();
        service.AddScoped<IProductStockRepository, ProductStockRepository>();

        // services
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<ITokenService, TokenService>();
        service.AddScoped<IProductService, ProductService>();
        service.AddScoped<ICategoryService, CategoryService>();

        // cqrs user
        service.AddScoped<IRequestHandler<CreateUserCommand, AppUser>, CreateUserCommandHandler>();
        service.AddScoped<IRequestHandler<GetAllUsersQuery, IEnumerable<AppUser>>, GetAllUsersHandler>();
        service.AddScoped<IRequestHandler<GetUserByIdQuery, AppUser?>, GetUserByIdHandler>();
        service.AddScoped<IRequestHandler<GetUserByEmailQuery, AppUser?>, GetUserByEmailHandler>();

        // cqrs role
        service.AddScoped<IRequestHandler<CreateRoleCommand, IdentityResult>, CreateRoleCommandHandler>();
        service.AddScoped<IRequestHandler<GetUserRoleQuery, IEnumerable<string>>, GetUserRoleHandler>();

        // cqrs category
        service.AddScoped<IRequestHandler<CreateCategoryCommand, Category>, CreateCategoryCommandHandler>();
        service.AddScoped<IRequestHandler<GetAllCategoryQuery, IEnumerable<Category>>, GetAllCategoryHandler>();
        service.AddScoped<IRequestHandler<GetCategoryByIdQuery, Category?>, GetCategoryByIdHandler>();
        service.AddScoped<IRequestHandler<GetCategoryByNameQuery, Category?>, GetCategoryByNameHandler>();

        // cqrs product
        service.AddScoped<IRequestHandler<CreateProductCommand, Product>, CreateProductCommandHandler>();
        service.AddScoped<IRequestHandler<GetAllProductQuery, IEnumerable<Product>>, GetAllProductHandler>();
        service.AddScoped<IRequestHandler<GetProductByIdQuery, Product?>, GetProductByIdHandler>();
        service.AddScoped<IRequestHandler<GetProductDetailByIdQuery, Product?>, GetProductDetailByIdHandler>();
        service.AddScoped<IRequestHandler<GetProductIncludeCategoryByIdQuery, Product?>, GetProductIncludeCategoryByIdHandler>();
        service.AddScoped<IRequestHandler<GetProductIncludeStockByIdQuery, Product?>, GetProductIncludeStockByIdHandler>();
        service.AddScoped<IRequestHandler<SoftDeleteProductCommand, string>, SoftDeleteProductCommandHandler>();

        return service;
    }
}
