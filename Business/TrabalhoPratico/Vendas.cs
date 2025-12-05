using System.Net.WebSockets;

public class Vendas
{
    public string Data { get; set; } //DD-MM-YY
    public string NomeProdutoVenda { get; set; }
    public string MarcaVenda { get; set; }
    public int Quantidade { get; set; }
    public string NomeClienteVenda { get; set; }

    //Construtor
    public Vendas(string data, string nomeProduto, string marca, int quantidade, string nomeCliente)
    {
        Data = data;
        NomeProdutoVenda = nomeProduto;
        MarcaVenda = marca;
        Quantidade = quantidade;
        NomeClienteVenda = nomeCliente;
    }
    public override string ToString()
    {
        return $"\nData da Venda:{Data} | Nome do Produto: {NomeProdutoVenda} | Marca do Produto:{MarcaVenda} | Quantidade Vendida:{Quantidade} | Nome do Cliente:{NomeClienteVenda}";
    }
}
