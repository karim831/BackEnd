using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.CustomValidationAttributes;

namespace ModelBinding.Models.Entities;
[Bind(nameof(OrderDate), nameof(InvoicePrice), nameof(Products))]
public class Order{
    public int? OrderNo {get; set;}

    [
        MinimumDateValidation,
        DisplayName("Order Date")
    ]
    public DateTime OrderDate {get; set;}

    [
        InvoicePriceValidation,
        DisplayName("Invoice Price")
    ]
    public double InvoicePrice {get; set;}
    
    [MinLength(1,ErrorMessage = "Order should have at least one product")]
    public List<Product> Products {get; set;} = [];

}