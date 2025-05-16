namespace SmartParking.Client.Commons.Entity.Response
{
    public class ResponseResult<T>
    {
        public string Msg { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }
    }

    public class ResponseResult
    {
        public string Msg { get; set; }
        public int Code { get; set; }
        public object Data { get; set; }
    }
}