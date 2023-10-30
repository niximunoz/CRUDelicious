#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage ="Por favor proporciona este dato!")]
    public string Name { get; set; }

    [Required(ErrorMessage ="Por favor proporciona este dato!")]
    public string Chef { get; set; }

    [Required(ErrorMessage ="Por favor proporciona este dato!")]
    [Range(1, 5, ErrorMessage = "El valor para {0} debe estar entre {1} y {2}.")]
    public int Tastiness {get;set;}
    [Required(ErrorMessage ="Por favor proporciona este dato!")]
    // [Minimum(0,ErrorMessage ="Por favor proporciona este dato!")]
    public int Calories {get;set;}
    [Required(ErrorMessage ="Por favor proporciona este dato!")]
    public string Description { get; set; }

    public DateTime FechaCreacion {get; set;} = DateTime.Now;

    public DateTime FechaActualizacion {get; set;} = DateTime.Now;
}