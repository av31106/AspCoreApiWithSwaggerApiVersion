namespace API2022WithSwegger.Models
{
    public class ResultReponse
    {
        public bool IsSussses { get; set; } = true;
        public Guid? ErrorId { get; set; } = null;
        public string? ErrorMessage { get; set; } = null;
        public string? ErrorType { get; set; } = null;
        public string? ErrorTypeDescription { get; set; } = null;
        public dynamic? Result { get; set; } = null;
    }
}
