public class Produto{
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Stock { get; set; }
    public string Categoria { get; set; }
    public string Marca { get; set; }
    public int Garantia { get; set; } //em anos exemplo 1 ou 1/2 anos

    public Produto(string nome, double preco, int stock,string categoria, string marca, int garantia )
    {
        Nome = nome;
        Preco = preco;
        Stock = stock;
        Categoria = categoria;
        Marca = marca;
        Garantia = garantia;
    }
    
    public override string ToString()
    {
        return $"\nNome: {Nome} | Preço:{Preco} | Stock:{Stock} | Categoria:{Categoria} | Marca:{Marca} | Garantia:{Garantia}";
        
    }

}