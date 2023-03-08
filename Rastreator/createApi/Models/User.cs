using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public string Email { get; set; }
    public string NomeDoProduto {get;set;}
    public string Empresa {get;set;}
    public string CodigoRastreio { get;set;}
    public DateTime DataDeCompra { get;set;} 
        
    // criar status e também um sistema de ranking??

    // criar tabela usuario e uma foreign key para produto

}