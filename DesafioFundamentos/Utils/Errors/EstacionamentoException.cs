namespace DesafioFundamentos.Utils.Errors
{
    public class EstacionamentoException: Exception
    {
        public EstacionamentoException()
        {
        }

        public EstacionamentoException(string message) : base(message)
        {
        }

        public EstacionamentoException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}