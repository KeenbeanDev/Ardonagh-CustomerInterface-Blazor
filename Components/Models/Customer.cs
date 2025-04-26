using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Ardonagh_CustomerInterface_Blazor.Components.Models;

public class Customer
{
    public Customer(string Name, int Age, string Postcode, double Height) {
        this.Name = Name;
        this.Age = Age;
        this.Postcode = Postcode;
        this.Height = Height;
    }

    [JsonPropertyName("Name")]
    [StringLength(50, ErrorMessage = "Name length cannot be more than 50 characters.")]
    public string? Name { get; set; }
    [JsonPropertyName("Age")]
    public int Age { get; set; }
    [JsonPropertyName("Postcode")]
    public string? Postcode { get; set; }
    [JsonPropertyName("Height")]
    public double Height { get; set; }
}