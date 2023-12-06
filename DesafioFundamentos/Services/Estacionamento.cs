using DesafioFundamentos.Models;
using EstacionamentoModel = DesafioFundamentos.Models.Estacionamento;
using DesafioFundamentos.Utils.Errors;
using DesafioFundamentos.Utils;

namespace DesafioFundamentos.Services
{
    public class Estacionamento
    {
        private EstacionamentoModel estacionamento;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            estacionamento = new EstacionamentoModel(precoInicial, precoPorHora);
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            try
            {
                estacionamento.AdicionarVeiculo(Console.ReadLine());
            }
            catch (EstacionamentoException e)
            {
                Console.WriteLine("Erro ao adicionar veículo: " + e.Message);
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa;
            bool existeVeiculo = false;
            
            placa = Console.ReadLine();

            try
            {
                existeVeiculo = estacionamento.ExisteVeiculo(placa) >= 0;
            }
            catch (EstacionamentoException)
            {
            }
            finally
            {
                // Verifica se o veículo existe
                if (existeVeiculo)
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    int horas = UserInputHandler.ReadNatural();
                    decimal valorTotal = estacionamento.CalcularPrecoTotalAPagar(horas); 

                    estacionamento.RemoverVeiculo(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total a pagar foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            var veiculos = estacionamento.ObterVeiculosEstacionados();
            if (veiculos.Count > 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}