using Business.Abstracts;
using Business.Concretes;
using Business.Validations;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business;
public static class ServiceRegistration
{
    public static void RegisterBusinessServices(this IServiceCollection services)
    {
        services.AddDbContext<BusinessDbContext>();
        services.AddSingleton<ITokenHelper, JWTTokenHelper>();

        services.AddScoped<ClaimValidations>();
        services.AddScoped<IClaimService, ClaimManager>();
        services.AddScoped<IClaimRepository, ClaimRepository>();

        services.AddScoped<UserValidations>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<AuthValidations>();
        services.AddScoped<IAuthService, AuthManager>();

        services.AddScoped<CategoryValidations>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<ProductValidations>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<CartItemValidations>();
        services.AddScoped<ICartItemService, CartItemManager>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();

        services.AddScoped<CartValidations>();
        services.AddScoped<ICartService, CartManager>();
        services.AddScoped<ICartRepository, CartRepository>();

        services.AddScoped<ProductCommentValidations>();
        services.AddScoped<IProductCommentService, ProductCommentManager>();
        services.AddScoped<IProductCommentRepository, ProductCommentRepository>();

        services.AddScoped<ProductStockTransactionValidations>();
        services.AddScoped<IProductStockTransactionService, ProductStockTransactionManager>();
        services.AddScoped<IProductStockTransactionRepository, ProductStockTransactionRepository>();

        services.AddScoped<IOrderItemService, OrderItemManager>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();

        services.AddScoped<IOrderService, OrderManager>();
        services.AddScoped<IOrderRepository, OrderRepository>();
    }
}
