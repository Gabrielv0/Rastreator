using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string NomeDoProduto { get; set; }
    [Required]
    public string Empresa { get; set; }
    [Required]
    public string CodigoRastreio { get; set; }
    [Required]
    public DateTime DataDeCompra { get; set; }

   

}
