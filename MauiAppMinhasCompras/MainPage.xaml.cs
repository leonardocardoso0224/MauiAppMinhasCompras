using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Produto> Produtos { get; set; }
    public ObservableCollection<Produto> ProdutosFiltrados { get; set; }

    public MainPage()
    {
        InitializeComponent();

        Produtos = new ObservableCollection<Produto>
        {
            new Produto { Nome = "Placa de Vídeo RX 7600" },
            new Produto { Nome = "Cabo de Rede Cat6 30m" },
            new Produto { Nome = "Goniômetro de Precisão" },
            new Produto { Nome = "Monitor Gamer 144hz" }
        };

        ProdutosFiltrados = new ObservableCollection<Produto>(Produtos);
        BindingContext = this;
    }

    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        var termoBusca = e.NewTextValue?.ToLower() ?? string.Empty;

        ProdutosFiltrados.Clear();

        foreach (var produto in Produtos.Where(p => p.Nome.ToLower().Contains(termoBusca)))
        {
            ProdutosFiltrados.Add(produto);
        }
    }
}

public class Produto
{
    public string Nome { get; set; }
}