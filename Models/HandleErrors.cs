namespace DesafioProjetoHospedagem.Models;
using System;


public class HandleErrors : Exception
{


    public string OvercapacityException(int qtdPessoa, int capacidade)
    {
        string messageError = $"A capacidad do quarto foi sobrepassada \r\n  O quarto só comporta {capacidade} \r\n  Mas  a reserva é para {qtdPessoa}.  \r\n Volte a refazer sua reserva";
            return messageError;
    }



      public string DescontFailException(decimal valor, decimal desconto)
    {
        string messageError = $"As informações passadas apresentarão erros \r\n  O Valor da recerba é {valor} tipo decimal \r\n O desconto: {desconto} tipo decimal.  \r\n Comprobe que os valores são corretos";
            return messageError;
    }
}
