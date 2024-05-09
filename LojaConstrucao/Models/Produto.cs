using System.ComponentModel.DataAnnotations;

namespace LojaConstrucao.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public string? NomeProduto { get; set; }

        public decimal Valor { get; set; }

        public string? Estoque { get; set; }
    }
}
