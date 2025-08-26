using System.ComponentModel.DataAnnotations;

namespace ModelBinding.CustomValidationAttributes;

public class MinimumDateValidationAttribute: ValidationAttribute{
    private readonly DateTime _minimumDate;
    public MinimumDateValidationAttribute():this(2000,1,1){}

    public MinimumDateValidationAttribute(int year, int month, int day){
        _minimumDate = new DateTime(year,month,day);
        ErrorMessage = $"{{0}} should be greater than or equal to {_minimumDate}";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext){
        if(DateTime.TryParse(value?.ToString(),out DateTime orderDate)){
            if(orderDate >= _minimumDate)
                return ValidationResult.Success;
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        return null;
    }
}