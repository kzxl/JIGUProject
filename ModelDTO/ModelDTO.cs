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
    public class CF
    {
        public string CFName { get; set; }
        public string Code { get; set; }
        public string CodeOther { get; set; }
        public string Note { get; set; }
        public string LocationOld { get; set; }
        public string QuantityOld { get; set; }
        public string LocationNew { get; set; }
        public string QuantityNew { get; set; }
    }
}
