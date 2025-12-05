public class Cliente
{
    public string NomeCliente { get; set; }
    public string Email { get; set; }
    public int Telemovel { get; set; }
    public string Morada { get; set; }

    public Cliente(string nome, string email, int telemovel, string morada)
    {
        NomeCliente = nome;
        Email = email;
        Telemovel = telemovel;
        Morada = morada;
    }
    public override string ToString()
    {
        return $"\nNome do Cliente:{NomeCliente} | Email:{Email} | Número de Telemovel:{Telemovel} | Morada:{Morada}";
    }
}