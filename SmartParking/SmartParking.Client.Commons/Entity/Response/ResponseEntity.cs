namespace SmartParking.Client.Commons.Models.Response
{
    public class ResponseEntity<T>
    {
        public string Msg { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }
    }
}