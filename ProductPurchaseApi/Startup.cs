// Startup.cs

using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using ProductPurchaseApi.Models;
using FluentValidation.AspNetCore;

namespace ProductPurchaseApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // ...

            services.AddMvc().AddFluentValidation();
            // Register the validator
            services.AddTransient<IValidator<ProductPurchaseApi.Models.ProductPurchase>, ProductPurchaseApi.Validators.ProductPurchaseValidator>();

        }
    }
}
