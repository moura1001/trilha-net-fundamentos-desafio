using DesafioFundamentos.Models;
using DesafioFundamentos.Utils.Errors;

namespace EstacionamentoTests;

public class EstacionamentoTests
{
    private Estacionamento es = new Estacionamento(5, 2);

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
}