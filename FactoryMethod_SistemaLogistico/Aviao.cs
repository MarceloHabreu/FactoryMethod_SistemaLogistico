using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod_SistemaLogistico
{
    public class Aviao : ITransporte
    {
            public string TipoTransporte => "Avião";

            // Frete aéreo é mais caro — taxa maior por km
            public decimal CalcularFrete(decimal distanciaKm, decimal pesoKg)
            {
                const decimal taxaBase = 8.0m;
                const decimal taxaPeso = 0.50m;
                return (distanciaKm * taxaBase) + (pesoKg * taxaPeso);
            }

            public void RealizarEntrega(string origem, string destino)
            {
                Console.WriteLine($"[AVIÃO] Decolando de {origem} com destino a {destino}.");
                Console.WriteLine("  → Rota aérea confirmada. Estimativa: 6 horas.");
            }

            public string ObterInformacoesTransporte()
            {
                return "Avião Cargueiro | Capacidade: 100 toneladas | Velocidade: 850 km/h";
            }
        }
}
