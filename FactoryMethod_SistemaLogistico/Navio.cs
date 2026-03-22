using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod_SistemaLogistico
{
    public class Navio: ITransporte
    {
            public string TipoTransporte => "Navio";

            // Frete marítimo: barato por km, mas cobra mais pelo peso
            public decimal CalcularFrete(decimal distanciaKm, decimal pesoKg)
            {
                const decimal taxaBase = 0.8m;
                const decimal taxaPeso = 0.05m;
                return (distanciaKm * taxaBase) + (pesoKg * taxaPeso);
            }

            public void RealizarEntrega(string origem, string destino)
            {
                Console.WriteLine($"[NAVIO] Partindo do porto de {origem} rumo a {destino}.");
                Console.WriteLine("  → Rota marítima traçada. Estimativa: 15 dias.");
            }

            public string ObterInformacoesTransporte()
            {
                return "Navio Cargueiro | Capacidade: 50.000 toneladas | Velocidade: 30 km/h";
            }
        }
}
