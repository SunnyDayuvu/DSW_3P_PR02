using System.ComponentModel.DataAnnotations;

namespace DSW_3P_PR02.Models;

public class Evento : IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; } = string.Empty;

    public string Categoria { get; set; } = string.Empty;

    public DateTime Fecha { get; set; }

    public string Lugar { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "El cupo debe ser mayor que cero.")]
    public int CupoMaximo { get; set; }

    public bool Activo { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Fecha == default)
        {
            yield return new ValidationResult(
                "La fecha es obligatoria y debe ser válida.",
                new[] { nameof(Fecha) });
        }
    }
}