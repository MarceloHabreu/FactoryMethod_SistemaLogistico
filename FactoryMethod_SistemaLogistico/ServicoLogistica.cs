using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod_SistemaLogistico
{
    public class ServicoLogistica
    {
        // Recebe a abstração — não a implementação concreta (DIP)
        public void ProcessarPedido(PedidoEntrega pedido)
        {
            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine($"  PEDIDO #{pedido.Id} — {pedido.DataSolicitacao:dd/MM/yyyy HH:mm}");
            Console.WriteLine("╚══════════════════════════════════════════════╝");

            // A FÁBRICA cria o transporte correto 
            ITransporte transporte = TransporteFactory.CriarTransporte(pedido.TipoTransporte);

            Console.WriteLine($"\n► Transporte selecionado: {transporte.TipoTransporte}");
            Console.WriteLine($"► Detalhes: {transporte.ObterInformacoesTransporte()}");

            // Calcula o frete usando o objeto criado pela fábrica
            decimal frete = transporte.CalcularFrete(pedido.DistanciaKm, pedido.PesoKg);

            Console.WriteLine($"\n► Distância: {pedido.DistanciaKm} km");
            Console.WriteLine($"► Peso: {pedido.PesoKg} kg");
            Console.WriteLine($"► Frete calculado: R$ {frete:F2}");

            Console.WriteLine();
            transporte.RealizarEntrega(pedido.Origem, pedido.Destino);
            Console.WriteLine();
        }

        // Compara fretes entre todos os transportes disponíveis
        public void CompararFretes(decimal distanciaKm, decimal pesoKg)
        {
            Console.WriteLine("┌─────────────────────────────────────────────┐");
            Console.WriteLine("│          COMPARATIVO DE FRETES              │");
            Console.WriteLine($"│  Distância: {distanciaKm} km  |  Peso: {pesoKg} kg           │");
            Console.WriteLine("└─────────────────────────────────────────────┘");

            foreach (var tipo in TransporteFactory.ObterTiposDisponiveis())
            {
                ITransporte t = TransporteFactory.CriarTransporte(tipo);
                decimal frete = t.CalcularFrete(distanciaKm, pesoKg);
                Console.WriteLine($"  {t.TipoTransporte,-12} → R$ {frete:F2}");
            }

            Console.WriteLine();
        }
    }
}
