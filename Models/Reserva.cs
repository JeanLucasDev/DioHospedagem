namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (this.Suite.Capacidade >= this.ObterQuantidadeHospedes())
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A capacidade é menor que o numero de hospedes");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            try
            {
                if (this.Hospedes != null)
                    return this.Hospedes.Count();
                else
                    return 0;
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("Erro {0}",e));
            }
        }

        public double CalcularValorDiaria()
        {
            double valor = 0;
            valor = Convert.ToDouble(DiasReservados) * Convert.ToDouble(Suite.ValorDiaria);
            if (this.DiasReservados >= 10)
            {
                valor = valor * 0.1;
            }

            return valor;
        }
    }
}