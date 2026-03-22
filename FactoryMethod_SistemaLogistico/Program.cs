
using FactoryMethod_SistemaLogistico;
using System;
using System.Collections.Generic;

namespace SistemaLogistica
{
  
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