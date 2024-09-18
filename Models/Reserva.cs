namespace DesafioProjetoHospedagem.Models
{


    public class Reserva
    {

        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        public int DiasParaDesconto = 10;
        public int descontoPromo = 10;
        bool comDesconto = false;
        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            int qtdPessoa = hospedes.Count;

            // *IMPLEMENTE AQUI*

            if (Suite.Capacidade >= qtdPessoa)
            {
                Hospedes = hospedes;
            }
            else
            {
                HandleErrors error = new HandleErrors();

                Console.WriteLine(error.OvercapacityException(Suite.Capacidade, qtdPessoa));

                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                // *IMPLEMENTE AQUI*

            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*

            return Hospedes.Count;
        }

        public string CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = 0;
            comDesconto = false;

            valor = DiasReservados * Suite.ValorDiaria;

            valor = CalcularDesconto(valor, descontoPromo);

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            
            return comDesconto? $"Tuviste un desconto Genial de {descontoPromo} el valor de tua Suite é : {valor}" : $"O valor da Suite é: {valor}, mas temos um desconto especial se reserva por 10 dias o mas, não perca!";
        }


        public decimal CalcularDesconto(decimal valor, decimal desconto)
        {

            decimal descontoTotal = 0;

            try
            {
                if (DiasReservados >= DiasParaDesconto)
                {
                    descontoTotal = valor - (valor * desconto / 100);
                    comDesconto = true;
                }
                else
                {
                    return valor;
                }


                return descontoTotal;
            }
            catch (System.Exception)
            {
                HandleErrors error = new HandleErrors();
                Console.WriteLine(error.DescontFailException(valor, desconto));
                return valor;
            }


        }
    }
}