using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Domain.Entities.Enum
{
    public enum StatusSolicitacao
    {
        [Description("Aguardando Processamento")]
        Pendente = 0,

        [Description("Em Processamento")]
        Aprovado = 1,

        [Description("Processado")]
        Recusado = 2
    }
}
