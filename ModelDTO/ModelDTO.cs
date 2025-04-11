namespace ModelDTO
{
    public class RequestDTO
    {
        public string Line { get; set; }
        public string CF { get; set; }
        public string CODE { get; set; }
        public int Quantity { get; set; }
    }
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
