using System;
using System.ComponentModel.DataAnnotations;

namespace pizza_project;

public class Pizza
{
    [Required]
    [RegularExpression(@"[\d]+$")]
    public int Id { get; set; }

    [StringLength(20, MinimumLength =2)]
    public string? Name { get; set; }
    [Required]
    public int Price { get; set; }
    public bool Gluten { get; set; }
}