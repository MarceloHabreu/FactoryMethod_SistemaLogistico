
    public interface ITransporte
    {
        string TipoTransporte { get; }
        decimal CalcularFrete(decimal distanciaKm, decimal pesoKg);
        void RealizarEntrega(string origem, string destino);
        string ObterInformacoesTransporte();
    }