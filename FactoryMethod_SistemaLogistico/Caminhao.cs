using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod_SistemaLogistico
{
    public class Caminhao: ITransporte
    {
            public string TipoTransporte => "Caminhão";

            // Frete calculado com taxa base por km + peso
            public decimal CalcularFrete(decimal distanciaKm, decimal pesoKg)
            {
                const decimal taxaBase = 2.5m;
                const decimal taxaPeso = 0.10m;
                return (distanciaKm * taxaBase) + (pesoKg * taxaPeso);
            }

            public void RealizarEntrega(string origem, string destino)
            {
                Console.WriteLine($"[CAMINHÃO] Saindo de {origem} com destino a {destino}.");
                Console.WriteLine("  → Rota terrestre calculada. Estimativa: 2 dias.");
            }

            public string ObterInformacoesTransporte()
            {
                return "Caminhão | Capacidade: 20 toneladas | Velocidade média: 80 km/h";
            }
        }

}
