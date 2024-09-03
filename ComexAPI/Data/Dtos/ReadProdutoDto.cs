using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.Dtos;

public class ReadProdutoDto
{
    [Required]
    [MaxLength(100, ErrorMessage = "O nome do produto não pode exceder 100 caracteres")]
    public string Nome { get; set; }
    [Required]
    [MaxLength(500, ErrorMessage = "A descrição do produto não pode exceder 500 caracteres")]
    public string Descricao { get; set; }

    [Required]
    [Range(1, 999999999, ErrorMessage = "O preço deve ser maior que 0")]
    public float Preco { get; set; }

    [Required]
    [Range(0, 999999999, ErrorMessage = "A quantidade pode ser igual ou maior que 0")]
    public int Quantidade { get; set; }

    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
