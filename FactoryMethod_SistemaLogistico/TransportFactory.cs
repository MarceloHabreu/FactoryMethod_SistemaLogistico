using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod_SistemaLogistico
{
    public static class TransporteFactory
        {
            // Factory Method: recebe o tipo e retorna a abstração ITransporte
            public static ITransporte CriarTransporte(TipoTransporteEnum tipo)
            {
                return tipo switch
                {
                    TipoTransporteEnum.Caminhao => new Caminhao(),
                    TipoTransporteEnum.Aviao => new Aviao(),
                    TipoTransporteEnum.Navio => new Navio(),

                    _ => throw new ArgumentException($"Tipo de transporte '{tipo}' não reconhecido.")
                };
            }

            // Método auxiliar: lista todos os tipos disponíveis
            public static IEnumerable<TipoTransporteEnum> ObterTiposDisponiveis()
            {
                return Enum.GetValues<TipoTransporteEnum>();
            }
        }
    
}
