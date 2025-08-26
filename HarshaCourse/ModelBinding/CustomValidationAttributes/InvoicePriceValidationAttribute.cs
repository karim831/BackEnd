using System.ComponentModel.DataAnnotations;
using ModelBinding.Models.Entities;

namespace ModelBinding.CustomValidationAttributes;

public class InvoicePriceValidationAttribute : ValidationAttribute{
    private readonly string _defaultMessage;
    public InvoicePriceValidationAttribute() => _defaultMessage = "{0} should be equal to the total cost of all products (i.e. {1}) in the order.";
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext){
        if(double.TryParse(value?.ToString(),out double invoicePrice)){
            var productsObject = validationContext.ObjectType.GetProperty("Products")?.GetValue(validationContext.ObjectInstance);
            if(productsObject is IEnumerable<Product> products){
                double totalPrice = products.Aggregate(0.0,(accum , product) => accum += product.Price * product.Quantity);
                if(totalPrice == invoicePrice)
                    return ValidationResult.Success;
                return new ValidationResult(string.Format(ErrorMessage ?? _defaultMessage, validationContext.DisplayName,totalPrice));
            }
            return new ValidationResult("Product List Is Required!");
        }
        return null;
    }
}