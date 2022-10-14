namespace JMApi.Model
{
    public class StatusViewModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object ObjetoADeserializar { get; set; }
        public string TipoMensaje { get; set; }
    }
}
