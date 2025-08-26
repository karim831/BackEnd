using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelBinding.Models.Entities;

public class Product{

    
    [   
        DisplayName("Product code"),
        Range(1,int.MaxValue,ErrorMessage = "{0} should be between valid number")
    ]
    public int ProductCode {get; set;}
    
    [   
        DisplayName("Price"),
        Range(.01, double.MaxValue,ErrorMessage = "{0} should be between valid number")
    ]
    public double Price {get; set;}
    
    [
        DisplayName("Quantity"),
        Range(.01, double.MaxValue,ErrorMessage = "{0} should be between valid number")
    ]
    public int Quantity {get; set;}

    public override string ToString() => 
        $"""
            productCode: {ProductCode},
            price: {Price},
            quantity: {Quantity}
        """;
}