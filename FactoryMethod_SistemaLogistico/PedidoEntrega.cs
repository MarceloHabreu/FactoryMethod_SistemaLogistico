using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod_SistemaLogistico
{
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
}
