namespace ModelDTO
{
    public class RequestDTO
    {
        public string Line { get; set; }
        public string CODE { get; set; }
        public string Quantity { get; set; }
    }
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
