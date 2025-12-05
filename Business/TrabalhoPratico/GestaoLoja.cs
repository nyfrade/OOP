using System.Collections.Specialized;
using System.Net.WebSockets;
using System.Security;

public class GestaoLoja
{
    public string NomeLoja { get; set; }
    private Produto[] produtos;
    private Cliente[] clientes;
    private Vendas[] vendas;
    private int contador1, contador2, contador3;

//Construtor 
    public GestaoLoja(string nome, int capacidade)
    {
        NomeLoja = nome;
        produtos = new Produto[capacidade];
        clientes = new Cliente[capacidade];
        vendas = new Vendas[capacidade];
        contador1 = 0;
        contador2 = 0;
        contador3 = 0;
    }
    //Metodo para adicionar produto
    public void AdicionarProduto(Produto produto)
    {
        if(contador1 < produtos.Length)
        {
            produtos[contador1] = produto;
            contador1++;
        }else
        {
            Console.WriteLine("Capacidade máxima atingida!");
        }
    }
    public void AdicionarCliente(Cliente cliente)
    {
        if(contador2 < clientes.Length)
        {
            clientes[contador2] = cliente;
            contador2++;
        }else
        {
            Console.WriteLine("Capacidade máxima atingida!");
        }
    }
    //Metodo para listar todos os produtos 
    public void ListarProdutos()
    {
        System.Console.WriteLine("\n--------------------------------\n");
        Console.WriteLine($"Produtos disponíveis na loja {NomeLoja}:");
        if (contador1 == 0) {
            System.Console.WriteLine("SEM PRODUTOS DISPONIVEIS");
        }
        for (int i = 0; i < contador1; i++)
        {
            Produto p = produtos[i];
            System.Console.WriteLine($"{i + 1} - {p}");
        }
        System.Console.WriteLine("\n--------------------------------\n\n");
    }
    //Metodo para listar todos os clientes
    public void ListarClientes()
    {
        System.Console.WriteLine("\n--------------------------------\n");
        Console.WriteLine($"Lista dos clientes de {NomeLoja}:");
        if (contador2 == 0) {
            System.Console.WriteLine("SEM CLIENTES DISPONIVEIS");
        }
        for (int i = 0; i < contador2; i++)
        {
            Cliente c = clientes[i];
            System.Console.WriteLine($"{i + 1} - {c}");
        }
        System.Console.WriteLine("\n--------------------------------\n\n");
    }
    //Metodo para remover produto
      // pesquisa produto por nome:
    // caso o produto existe, devolve a posicao respetiva no array
    // caso o produto nao exista, devolve -1
    private int PesquisarProduto(string nome)
    {
        int posicaoProduto = -1;
        for (int i = 0; i < contador1; i++)
        {
            Produto p = produtos[i];
            if (p.Nome.Equals(nome, StringComparison.CurrentCultureIgnoreCase))
            {
               posicaoProduto = i;
               break;
            }
        }

        return posicaoProduto;
    }

    public void RemoveProduto(string nome)
    {
        int indice = PesquisarProduto(nome);
        if (indice != -1) {
            for (int i = indice; i < contador1 - 1; i++) {
                produtos[i] = produtos[i + 1]; // shift para a esquerda
            }
            produtos[contador1 - 1] = null; // limpa o ultimo elemento
            contador1--;
            System.Console.WriteLine("Produto removido");
        }
        else {
            System.Console.WriteLine("Produto nao encontrado");
        }
    }
    
    //Metodos para pesquisar cliente e logo remover 
    private int PesquisarCliente(string nome)
    {
        int posicaoCliente = -1;
        for (int i = 0; i < contador2; i++)
        {
            Cliente c = clientes[i];
            if (c.NomeCliente.Equals(nome, StringComparison.CurrentCultureIgnoreCase))
            {
               posicaoCliente = i;
               break;
            }
        }

        return posicaoCliente;
    }

    public void RemoveCliente(string nome)
    {
        int indice = PesquisarCliente(nome);
        if (indice != -1) {
            for (int i = indice; i < contador2 - 1; i++) {
                clientes[i] = clientes[i + 1]; // shift para a esquerda
            }
            clientes[contador2 - 1] = null; // limpa o ultimo elemento
            contador2--;
            System.Console.WriteLine("Cliente removido");
        }
        else {
            System.Console.WriteLine("Cliente nao encontrado");
        }
    }
    //Metodo para pesquisar produtos por categoria 
    public void PesquisarProdutoPorCategoria(string categoria)
    {
        for (int i = 0; i < contador1; i++)
        {
            Produto p = produtos[i];
            
            if (p.Categoria.Contains(categoria))
            {
                System.Console.WriteLine(p);
            }
        }
    }
    //Metodo para pesquisar produtos por Nome 
    public void PesquisarProdutoPorNome(string nome)
    {
        bool encontrou = false;
        for (int i = 0; i < contador1; i++)
        {
            Produto p = produtos[i];
            
            if (p.Nome.Contains(nome))
            {
                System.Console.WriteLine(p);
                encontrou = true;
            }
        }
        if (!encontrou)
        {
            Console.WriteLine("Cliente não encontrado!");
        }
    }
    //Metodo para pesquisar produtos por marca
    public void PesquisarProdutoPorMarca(string marca)
    {
        for (int i = 0; i < contador1; i++)
        {
            Produto p = produtos[i];
            if (p.Marca.Contains(marca))
            {
                System.Console.WriteLine(p);
            }
        }
    }
    //Metodo para pesquisar cliente por nome 
    public void PesquisarClientePorNome(string nome)
    {
        bool encontrou = false;
        for (int i = 0; i < contador2; i++)
        {
            Cliente c = clientes[i];
            
            if (c.NomeCliente.Contains(nome))
            {
                System.Console.WriteLine(c);
                encontrou = true;
            }
        }
        if (!encontrou)
        {
            Console.WriteLine("Cliente não encontrado!");
        }
    }
    //Metodo para pesquisar cliente por numero de telemovel
    public void PesquisarClientePorTelemovel(int telemovel)
    {
        bool encontrou = false;
        for (int i = 0; i < contador2; i++)
        {
            Cliente c = clientes[i];
            
            if (c.Telemovel.Equals(telemovel))
            {
                System.Console.WriteLine(c);
                encontrou = true;
            }
        }
        if (!encontrou)
        {
            Console.WriteLine("Cliente não encontrado!");
        }
    }
    //Metodo para registrar Vendas
    public void RegistrarVendas(Vendas venda)
    {
        bool encontrou = false;
        for (int i = 0; i < contador1; i++)
        {
            Produto p = produtos[i];
            
            if(p.Nome.Contains(venda.NomeProdutoVenda) && p.Stock >= venda.Quantidade)
            {
                 if(contador3 < vendas.Length)
                 {
                    vendas[contador3] = venda;
                    p.Stock -= venda.Quantidade;
                    contador3++;
                    encontrou = true;
                    Console.WriteLine("Venda registrada com sucesso");
                 }else
                 {
                    Console.WriteLine("Capacidade máxima atingida!");
                 }
            }
        }

        if (!encontrou)
        {
            Console.WriteLine("Venda não registrada: alguma informação não é valida");
        }
    }
    //Metodo para listar vendas 
    public void ListarVendas()
    {
        System.Console.WriteLine("\n--------------------------------\n");
        Console.WriteLine($"Lista das vendas de {NomeLoja}:");
        for(int i = 0; i < contador3; i++)
        {
            Console.WriteLine(vendas[i]);
        }
        System.Console.WriteLine("\n--------------------------------\n");
    }
    //Metodo para pesquisar vendas por data
    public void PesquisarVendasPorData(string data)
    {
        for (int i = 0; i < contador3; i++)
        {
            Vendas v = vendas[i];
            
            if (v.Data.Contains(data))
            {
                System.Console.WriteLine(v);
            }
        }
    }
    //Metodo para pesquisar vendas por nome do cliente 
    public void PesquisarVendasPorCliente(string cliente)
    {
        for (int i = 0; i < contador3; i++)
        {
            Vendas v = vendas[i];
            
            if (v.NomeClienteVenda.Contains(cliente))
            {
                System.Console.WriteLine(v);
            }
        }
    }
    //Metodo pesquisar vendas de certo produto
    public void PesquisarVendasPorProduto(string produto)
    {
        for (int i = 0; i < contador3; i++)
        {
            Vendas v = vendas[i];
            
            if (v.NomeProdutoVenda.Contains(produto))
            {
                System.Console.WriteLine(v);
            }
        } 
    }
    //Metodo para listar os produtos e o stock
    public void ListarStock()
    {
        Console.WriteLine($"Stock dos produtos disponíveis na loja {NomeLoja}:");
        for(int i = 0; i < contador1; i++)
        {
            System.Console.WriteLine($"Produto: {produtos[i].Nome}, Stock: {produtos[i].Stock}");
            if(produtos[i].Stock <= 5)
            {
                System.Console.WriteLine($"AVISO!! Produto {produtos[i].Nome} com stock baixo");
            }
        }
    }
    //Metodo para consultar stock de um determinado produto
    public void ConsultarStock(string nome)
    {
        for (int i = 0; i < contador1; i++)
        {
            Produto p = produtos[i];
            
            if (p.Nome.Contains(nome))
            {
                System.Console.WriteLine($"Produto {p.Nome}, Stock: {p.Stock}");
            }
        }
    }
    //Metodo para pesquisar produtos de uma marca com certos anos de garantia 
    public void PesquisarProdutosPorGarantia(int garantia, string marca)
    {
      Console.WriteLine($"Produtos da marca '{marca}' com garantia igual a {garantia} anos:");
        bool encontrou = false;

        for (int i = 0; i < contador1; i++)
        {
         if (produtos[i].Marca.Equals(marca, StringComparison.OrdinalIgnoreCase) && produtos[i].Garantia == garantia)
            {
                 Console.WriteLine(produtos[i]);
                 encontrou = true;
            }
        }

        if (!encontrou)
        {
            Console.WriteLine("Nenhum produto foi encontrado.");
         }
    }
        //Metodo para alterar garantia de um produto
    public void AlterarGarantia(int garantia, string nome)
    {
        bool encontrou = false;

        for (int i = 0; i < contador1; i++)
        {
            if (produtos[i].Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                produtos[i].Garantia = garantia ;
                encontrou = true;
                Console.WriteLine("Garantia do produto alterada com exito!");
                Console.WriteLine(produtos[i]);
            }
        }

        if (!encontrou)
        {
            Console.WriteLine("Nenhum produto foi encontrado.");
        }
    }
    //Metodo para alterar preço de um produto
    public void AlterarPreçoProduto(double preco, string nome)
    {
        bool encontrou = false;

        for (int i = 0; i < contador1; i++)
        {
            if (produtos[i].Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                produtos[i].Preco = preco ;
                encontrou = true;
                Console.WriteLine("Preço do produto alterado com exito!");
                Console.WriteLine(produtos[i]);
            }
        }

        if (!encontrou)
        {
            Console.WriteLine("Nenhum produto foi encontrado.");
        }
    }
    //Metodo para registrar campanhas por marcas e aplicar descontos 
    public void RegistrarCampanhaPorMarca(string marca, float percentagem)
    {
        double novoPercentagem;
        bool encontrou = false;
        System.Console.WriteLine($"Lista dos produtos com descontos:");
        for (int i = 0; i < contador1; i++)
        {
            Produto p = produtos[i];
            if(p.Marca.Equals(marca, StringComparison.OrdinalIgnoreCase))
            {
                if (p.Marca.Contains(marca))
                {
                    novoPercentagem = p.Preco * (percentagem/100.0f);
                    p.Preco -= novoPercentagem;
                    encontrou = true;
                }
            
                if (p.Marca.Contains(marca))
                {
                    System.Console.WriteLine($"Nome do Produto: {p.Nome}, Novo preço: {p.Preco}");
                }    
            }
        }
        if (!encontrou)
        {
            Console.WriteLine("Marca não encontrada");
        }else{
            System.Console.WriteLine($"Registro de Campanha da marca {marca} com sucesso");
        }

    }
    //Metodo para registrar campanha por categoria 
    public void RegistrarCampanhaPorCategoria(string categoria, float percentagem)
    {
        double novoPercentagem;
        bool encontrou = false;
        System.Console.WriteLine($"Lista dos produtos com descontos:");
        for (int i = 0; i < contador1; i++)
        {
            Produto p = produtos[i];
            if(p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
            {
            if (p.Marca.Contains(categoria))
            {
                novoPercentagem = p.Preco * (percentagem/100);
                p.Preco = novoPercentagem;
                encontrou = true;
            }
             if (p.Categoria.Contains(categoria))
            {
                System.Console.WriteLine($"Nome do Produto: {p.Nome}, Novo preço: {p.Preco}");
            }
            }
        }
        if (!encontrou)
        {
            Console.WriteLine("Categoria não encontrada");
        }else{
            System.Console.WriteLine($"Registro de Campanha da categoria {categoria} com sucesso");
        }
    }
}




