using System.Text.Json;

System.Console.WriteLine("Insira o nome da sua loja:");
string nomeLoja = Console.ReadLine();
GestaoLoja gestaoLoja = new GestaoLoja(nomeLoja, 30);
string filepath = @"C:\Users\Valezka\OneDrive\Ambiente de Trabalho\programação objetos\TrabalhoPratico\gestaoLoja.json"; // alterar para o ficheiro do teu pc
int opcao;

do
{
    System.Console.WriteLine("==== MENU ====");
    System.Console.WriteLine("1 - Adicionar produto");
    System.Console.WriteLine("2 - Alterar preço de um produto");
    System.Console.WriteLine("3 - Remover produto");
    System.Console.WriteLine("4 - Lista de produtos: "); 
    System.Console.WriteLine("5 - Pesquisar produto por nome: ");
    System.Console.WriteLine("6 - Pesquisar produtos por categoria: ");
    System.Console.WriteLine("7 - Pesquisar produtos por marca:  ");
    System.Console.WriteLine("8 - Adicionar cliente");
    System.Console.WriteLine("9 - Remover cliente");
    System.Console.WriteLine("10 - Lista de clientes: ");
    System.Console.WriteLine("11 - Pesquisar cliente por número de telémovel: ");
    System.Console.WriteLine("12 - Pesquisar cliente por nome: ");
    System.Console.WriteLine("13 - Registar venda");
    System.Console.WriteLine("14 - Lista de vendas: ");
    System.Console.WriteLine("15 - Pesquisar vendas por data: "); 
    System.Console.WriteLine("16 - Pesquisar vendas por nome do cliente: ");
    System.Console.WriteLine("17 - Pesquisar vendas por produto: ");
    System.Console.WriteLine("18 - Lista de stock");
    System.Console.WriteLine("19 - Consultar stock por produto");
    System.Console.WriteLine("20 - Registar campanhas associadas a uma marca");
    System.Console.WriteLine("21 - Registar campanhas associadas a uma categoria");
    System.Console.WriteLine("22 - Pesquisar garantia (anos) por marca"); // num int
    System.Console.WriteLine("23 - Alterar garantia por produto");
    System.Console.WriteLine("24- Ler dados da loja no ficheiro");
    System.Console.WriteLine("25- Guardar dados no ficheiro");
    System.Console.WriteLine("0 - Sair");
    
    System.Console.WriteLine("Bem vindo! Escolha uma opção: ");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1: LeDadosProduto(); break;
        case 2: AlteraPreçoProduto(); break;
        case 3: RemovProduto(); break;
        case 4: gestaoLoja.ListarProdutos(); break;
        case 5: PesquisaPorNomeProduto(); break;
        case 6: PesquisaPorCategoria(); break;
        case 7: PesquisaPorMarcaProduto(); break;
        case 8: LeDadosCliente(); break;
        case 9: RemovCliente(); break;
        case 10: gestaoLoja.ListarClientes(); break;
        case 11: PesquisaPorTelemovelCliente(); break;
        case 12: PesquisaPorNomeCliente(); break;
        case 13: RegistroVendas(); break;
        case 14: gestaoLoja.ListarVendas(); break;
        case 15: PesquisaVendasPorData(); break;
        case 16: PesquisaVendasPorCliente(); break;
        case 17: PesquisaVendasPorProduto(); break;
        case 18: gestaoLoja.ListarStock(); break;
        case 19: ConsultaStock(); break;
        case 20: RegistroCampanhaMarca(); break;
        case 21: RegistroCampanhaCategoria(); break;
        case 22: PesquisaProdutoPorGrantia(); break;
        case 23: AlteraGarantia(); break;
        case 24: LeGestaoLoja(); break;
        case 25: GravaGestoLoja(gestaoLoja); break;
        case 0: System.Console.WriteLine("Obrigado por usar o sistema!"); break;
        
    }
} while (opcao != 0);

void LeDadosProduto() {
    System.Console.Write("Nome do Produto: ");
    string nome = Console.ReadLine();
    nome = nome.ToLower();
    System.Console.Write("Preço do Produto: ");
    double preco = double.Parse(Console.ReadLine());
    System.Console.Write("Stock: ");
    int stock = int.Parse(Console.ReadLine());
    System.Console.Write("Categoria do Produto:");
    string categoria = Console.ReadLine();
    categoria = categoria.ToLower();
    System.Console.Write("Marca do Produto:");
    string marca = Console.ReadLine();
    marca = marca.ToLower();
    System.Console.Write("Anos de garantia do produto:");
    int garantia = int.Parse(Console.ReadLine());

    Produto p = new Produto(nome, preco, stock, categoria, marca, garantia);
    gestaoLoja.AdicionarProduto(p);
}
void LeDadosCliente()
{
    System.Console.Write("Nome do Cliente:");
    string nome = Console.ReadLine();
    nome.ToLower();
    System.Console.Write("Email do Cliente:");
    string email = Console.ReadLine();
    email.ToLower();
    System.Console.Write("Telemóvel:");
    int telemovel = int.Parse(Console.ReadLine());
    System.Console.Write("Morada:");
    string morada = Console.ReadLine();
    morada.ToLower();
    
    Cliente c = new Cliente(nome, email, telemovel, morada);
    gestaoLoja.AdicionarCliente(c);
}

void RemovProduto() 
{
    System.Console.Write("Nome do produto a remover: ");
    string nome = Console.ReadLine();
    nome.ToLower();

    gestaoLoja.RemoveProduto(nome);
     
}

void RemovCliente()
{
    System.Console.Write("Nome do cliente a remover: ");
    string nome = Console.ReadLine();
    nome.ToLower();

    gestaoLoja.RemoveCliente(nome);
}

void PesquisaPorCategoria()
{
    System.Console.WriteLine("Insira a categoria para pesquisar os produtos disponíveis:");
    string categoria = Console.ReadLine();
    categoria.ToLower();

    gestaoLoja.PesquisarProdutoPorCategoria(categoria);
}

void PesquisaPorNomeProduto()
{
    System.Console.WriteLine("Insira o nome do produto:");
    string nome = Console.ReadLine();
    nome = nome.ToLower();

    gestaoLoja.PesquisarProdutoPorNome(nome);
}

void PesquisaPorMarcaProduto()
{
    System.Console.WriteLine("Insira a marca para pesquisar os produtos disponíveis:");
    string marca = Console.ReadLine();
    marca = marca.ToLower();

    gestaoLoja.PesquisarProdutoPorMarca(marca);
}

void PesquisaPorNomeCliente()
{
    System.Console.WriteLine("Insira o nome do cliente:");
    string nome = Console.ReadLine();
    nome = nome.ToLower();

    gestaoLoja.PesquisarClientePorNome(nome);
}

void PesquisaPorTelemovelCliente()
{
    System.Console.WriteLine("Insira o número de telemóvel do cliente:");
    int telemovel = int.Parse(Console.ReadLine());

    gestaoLoja.PesquisarClientePorTelemovel(telemovel);
}

void RegistroVendas()
{
    System.Console.Write("Data da venda (dd-mm-aaaa):");
    string data = Console.ReadLine();
    System.Console.Write("Nome do Produto:");
    string nomeProduto = Console.ReadLine();
    nomeProduto = nomeProduto.ToLower();
    System.Console.Write("Marca do produto:");
    string marca = Console.ReadLine();
    marca = marca.ToLower();
    System.Console.Write("Quantidade do produto comprado:");
    int quantidade = int.Parse(Console.ReadLine());
    System.Console.Write("Nome do Cliente:");
    string nomeCliente = Console.ReadLine();
    nomeCliente = nomeCliente.ToLower();

    Vendas v = new Vendas(data, nomeProduto, marca, quantidade, nomeCliente);
    gestaoLoja.RegistrarVendas(v);
}

void PesquisaVendasPorData() 
{
    System.Console.WriteLine("Data da venda (dd-mm-aaaa): ");
    string data = Console.ReadLine();
    
    gestaoLoja.PesquisarVendasPorData(data);

}

void PesquisaVendasPorCliente()
{
    System.Console.WriteLine("Insira o nome do cliente: ");
    string nome = Console.ReadLine();
    nome = nome.ToLower();

    gestaoLoja.PesquisarVendasPorCliente(nome);
}

void PesquisaVendasPorProduto()
{
    System.Console.WriteLine("Insira o nome do produto: ");
    string nome = Console.ReadLine();
    nome = nome.ToLower();

    gestaoLoja.PesquisarVendasPorProduto(nome);
}


void AlteraGarantia()
{
    System.Console.WriteLine("Nome do produto: ");
    string nome = Console.ReadLine();
    nome = nome.ToLower();
    System.Console.WriteLine("Nova garantia (em anos): ");
    int novaGarantia = int.Parse(Console.ReadLine());

    gestaoLoja.AlterarGarantia(novaGarantia, nome);
}

void AlteraPreçoProduto()
{
    System.Console.WriteLine("Nome do produto: ");
    string nome = Console.ReadLine();
    nome = nome.ToLower();
    System.Console.WriteLine("Insira o novo preço: ");
    double novoPreco = double.Parse(Console.ReadLine());

    gestaoLoja.AlterarPreçoProduto(novoPreco, nome);

}

void ConsultaStock()
{
    System.Console.WriteLine("Insira o nome do produto: ");
    string nome = Console.ReadLine();
    nome = nome.ToLower();
    
    gestaoLoja.ConsultarStock(nome);  
}

void PesquisaProdutoPorGrantia()
{
    System.Console.WriteLine("Anos de garantia que quer pesquisar: ");
    int garantia = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Marca dos produtos: ");
    string marca = Console.ReadLine();
    marca = marca.ToLower();

    gestaoLoja.PesquisarProdutosPorGarantia(garantia, marca);

}

void RegistroCampanhaMarca()
{
    System.Console.Write("Insira o nome da marca na qual quer fazer a Campanha:");
    string marca = Console.ReadLine();
    marca = marca.ToLower();
    System.Console.Write("Insira a percentagem de desconto:");
    float percentagem = float.Parse(Console.ReadLine());

    gestaoLoja.RegistrarCampanhaPorMarca(marca, percentagem);
}

void RegistroCampanhaCategoria()
{
    System.Console.Write("Insira o nome da categoria na qual quer fazer a Campanha:");
    string categoria = Console.ReadLine();
    categoria = categoria.ToLower();
    System.Console.Write("Insira a percentagem de desconto:");
    float percentagem = float.Parse(Console.ReadLine());

    gestaoLoja.RegistrarCampanhaPorCategoria(categoria, percentagem);
}

void GravaGestoLoja(GestaoLoja gestao)
{
    var options = new JsonSerializerOptions { WriteIndented = true };
    string conteudo = JsonSerializer.Serialize(gestao, options);
    File.WriteAllText(filepath, conteudo);
    Console.WriteLine("Gestão da loja guardada com sucesso. ");
}

GestaoLoja LeGestaoLoja() 
{
    string conteudo = File.ReadAllText(filepath);
    return JsonSerializer.Deserialize<GestaoLoja>(conteudo);
}