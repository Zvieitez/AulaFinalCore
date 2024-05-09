namespace LojaConstrucao.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string? NomeCliente { get; set; } //=string.Empty é a mesma coisa de colocar a interrogação após "string"

        public string Email { get; set; } = string.Empty;

         


        //explicitar o construtor, dessa forma fica obrigatório colocar todas as infos que constam nos parâmetros
        //public Cliente(int clienteid, string nomecliente, string email) {
        //ClienteId = clienteid;
        //NomeCliente = nomecliente;
        //Email = email;
    }
}
