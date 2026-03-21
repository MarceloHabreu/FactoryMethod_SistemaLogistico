
using System;
using System.Collections.Generic;

namespace SistemaLogistica
{

    // --- TRANSPORTE 1: Caminhão ---
    public class Caminhao : ITransporte
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

    // --- TRANSPORTE 2: Avião ---
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

    // --- TRANSPORTE 3: Navio ---
    public class Navio : ITransporte
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

    // --- Enum para os tipos disponiveis (evita "magic strings") ---
    public enum TipoTransporteEnum
    {
        Caminhao,
        Aviao,
        Navio
    }

    // --- A FABRICA ---
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

    public class PedidoEntrega
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public decimal DistanciaKm { get; set; }
        public decimal PesoKg { get; set; }
        public TipoTransporteEnum TipoTransporte { get; set; }
        public DateTime DataSolicitacao { get; set; } = DateTime.Now;

        public PedidoEntrega(int id, string origem, string destino,
                             decimal distanciaKm, decimal pesoKg,
                             TipoTransporteEnum tipo)
        {
            Id = id;
            Origem = origem;
            Destino = destino;
            DistanciaKm = distanciaKm;
            PesoKg = pesoKg;
            TipoTransporte = tipo;
        }
    }

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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("   SISTEMA DE LOGÍSTICA — SOLID + Factory    ");
            Console.WriteLine("==============================================\n");

            var servico = new ServicoLogistica();

            // Pedido 1: entrega terrestre (mercadoria pesada, distância média)
            var pedido1 = new PedidoEntrega(
                id: 1001,
                origem: "São Paulo/SP",
                destino: "Belo Horizonte/MG",
                distanciaKm: 586,
                pesoKg: 1200,
                tipo: TipoTransporteEnum.Caminhao
            );

            // Pedido 2: entrega aérea urgente (carga leve, longa distância)
            var pedido2 = new PedidoEntrega(
                id: 1002,
                origem: "São Paulo/SP",
                destino: "Manaus/AM",
                distanciaKm: 2694,
                pesoKg: 150,
                tipo: TipoTransporteEnum.Aviao
            );

            // Pedido 3: exportação marítima (carga massiva)
            var pedido3 = new PedidoEntrega(
                id: 1003,
                origem: "Santos/SP",
                destino: "Rotterdam/Holanda",
                distanciaKm: 9800,
                pesoKg: 45000,
                tipo: TipoTransporteEnum.Navio
            );

            // Processa cada pedido
            servico.ProcessarPedido(pedido1);
            servico.ProcessarPedido(pedido2);
            servico.ProcessarPedido(pedido3);

            // Comparativo de fretes para uma rota específica
            servico.CompararFretes(distanciaKm: 1000, pesoKg: 500);

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}