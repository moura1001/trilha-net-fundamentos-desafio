namespace DesafioFundamentos.Utils
{
    public class UserInputHandler
    {
        public static int ReadNatural()
        {
            int result;
            bool isValidInput;

            do
            {
                string input = Console.ReadLine();
                isValidInput = int.TryParse(input, out result) && result > 0;
                if (!isValidInput)
                    Console.WriteLine($"Entrada '{input}' é um valor inválido. Deve ser um número inteiro maior que 0. Por favor, tente novamente e digite uma entrada válida:");

            } while (!isValidInput);

            return result;
        }
    }
}