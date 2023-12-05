using DesafioFundamentos.Models;
using EstacionamentoModel = DesafioFundamentos.Models.Estacionamento;
using DesafioFundamentos.Utils.Errors;

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

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = "";

            // Verifica se o veículo existe
            if (estacionamento.ExisteVeiculo(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = 0;
                decimal valorTotal = 0; 

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (estacionamento.ObterVeiculosEstacionados().Count > 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}