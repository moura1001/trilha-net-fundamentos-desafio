using System.Text.RegularExpressions;
using DesafioFundamentos.Utils.Errors;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public bool EhPlacaValida(string placa)
        {
            return Regex.IsMatch(placa, "^[a-zA-Z]{3}[0-9][a-zA-Z][0-9]{2}$|^[a-zA-Z]{3}[0-9]{4}$");
        }
        
        public int ExisteVeiculo(string placa)
        {
            if (!EhPlacaValida(placa))
            {
                throw new EstacionamentoException($"placa {placa} é inválida");
            }
            return veiculos.FindIndex(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase));
        }

        public void AdicionarVeiculo(string placa)
        {
            // Verifica se o veículo existe
            if (ExisteVeiculo(placa) < 0)
            {
                veiculos.Add(placa);
                return;
            }

            throw new EstacionamentoException($"veículo de placa {placa} já está estacionado");
        }

        public void RemoverVeiculo(string placa)
        {
            // Verifica se o veículo existe
            int index = ExisteVeiculo(placa);
            
            if (index >= 0)
            {
                veiculos.RemoveAt(index);
                return;
            }

            throw new EstacionamentoException($"veículo de placa {placa} não está no estacionamento");
        }

        public List<string> ObterVeiculosEstacionados()
        {
            return new List<string>(veiculos);
        }

        public decimal CalcularPrecoTotalAPagar(int horasEstacionado)
        {
            return precoInicial + precoPorHora * horasEstacionado;
        }
    }
}
