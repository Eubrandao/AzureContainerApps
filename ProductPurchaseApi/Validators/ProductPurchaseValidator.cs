// Validators/ProductPurchaseValidator.cs

using FluentValidation;

namespace ProductPurchaseApi.Validators
{
    public class ProductPurchaseValidator : AbstractValidator<ProductPurchaseApi.Models.ProductPurchase>
    {
        public ProductPurchaseValidator()
        {
            RuleFor(p => p.Produto).NotEmpty();
            RuleFor(p => p.Valor).GreaterThan(0);
            RuleFor(p => p.Quantidade).GreaterThan(0);
        }
    }
}
