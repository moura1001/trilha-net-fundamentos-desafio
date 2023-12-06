using DesafioFundamentos.Models;
using DesafioFundamentos.Utils.Errors;

namespace EstacionamentoTests;

public class EstacionamentoTests : IDisposable
{
    private Estacionamento es;

    // setup
    public EstacionamentoTests()
    {
        es = new Estacionamento(5, 2);
    }

    // teardown
    public void Dispose()
    {
    }

    [Fact]
    public void DeveAdicionarVeiculoComPlacaValida()
    {
        string placa1 = "ABC1234";
        string placa2 = "ABC1D23";

        var exception = Record.Exception(() => es.AdicionarVeiculo(placa1));
        Assert.Null(exception);
        
        exception = Record.Exception(() => es.AdicionarVeiculo(placa2));
        Assert.Null(exception);

        List<string> veiculos = es.ObterVeiculosEstacionados();
        Assert.Equal(2, veiculos.Count);
        Assert.Equal(placa1, veiculos[0]);
        Assert.Equal(placa2, veiculos[1]);
    }

    [Fact]
    public void NaoDeveAdicionarVeiculoComPlacaInvalida()
    {
        string placa = "A1C1234";

        Assert.Throws<EstacionamentoException>(() => es.AdicionarVeiculo(placa));
        
        List<string> veiculos = es.ObterVeiculosEstacionados();
        Assert.Empty(veiculos);
    }

    [Fact]
    public void NaoDeveAdicionarVeiculoQueJaExiste()
    {
        string placa1 = "ABC1234";
        string placa2 = "ABC1D23";

        es.AdicionarVeiculo(placa1);        
        es.AdicionarVeiculo(placa2);

        Assert.Throws<EstacionamentoException>(() => es.AdicionarVeiculo(placa1));

        List<string> veiculos = es.ObterVeiculosEstacionados();
        Assert.Equal(2, veiculos.Count);
        Assert.Equal(placa1, veiculos[0]);
        Assert.Equal(placa2, veiculos[1]);
    }

    [Fact]
    public void DeveRemoverVeiculoEstacionadoECalcularOPrecoTotalAPagarCorretamente()
    {
        string placa1 = "ABC1234";
        string placa2 = "ABC1D23";

        es.AdicionarVeiculo(placa1);        
        es.AdicionarVeiculo(placa2);

        var exception = Record.Exception(() => es.RemoverVeiculo(placa1));
        Assert.Null(exception);

        decimal resultado = es.CalcularPrecoTotalAPagar(4);
        Assert.Equal(13m, resultado);

        List<string> veiculos = es.ObterVeiculosEstacionados();
        Assert.Single(veiculos);
        Assert.Equal(placa2, veiculos[0]);
    }

    [Fact]
    public void NaoDeveRemoverVeiculoQueNaoExisteOuSeTratarDeUmaPlacaInvalida()
    {
        string placa1 = "ABC1234";
        string placa2 = "ABC1D23";
        string placaNaoExiste = "CAB4231";
        string placaInvalida = "9AB4231";

        es.AdicionarVeiculo(placa1);        
        es.AdicionarVeiculo(placa2);

        Assert.Throws<EstacionamentoException>(() => es.RemoverVeiculo(placaNaoExiste));
        Assert.Throws<EstacionamentoException>(() => es.RemoverVeiculo(placaInvalida));

        List<string> veiculos = es.ObterVeiculosEstacionados();
        Assert.Equal(2, veiculos.Count);
        Assert.Equal(placa1, veiculos[0]);
        Assert.Equal(placa2, veiculos[1]);
    }
}