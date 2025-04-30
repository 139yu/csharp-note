namespace SmartParking.Server.Common.Entities.Response
{
    public class ResponseEntity<T>
    {
        public string Msg { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }
        public static ResponseEntity<T> Success(int code, T data, string msg)
        {
            return new ResponseEntity<T> { Code = code, Data = data, Msg = msg };
        }

        public static ResponseEntity<T> Success(T data, string msg)
        {
            return Success(200,data,msg);
        }
        
        public static ResponseEntity<T> Success(T data)
        {
            return Success(data,ResponseEntity.SuccessMsg);
        }
        public static ResponseEntity<T> Success()
        {
            return new ResponseEntity<T> { Code = 200, Msg = ResponseEntity.SuccessMsg };
        }

        public static ResponseEntity<T> Failed(string msg)
        {
            return new ResponseEntity<T> { Code = 500, Msg = msg };
        }
        
        public static ResponseEntity<T> Failed()
        {
            return new ResponseEntity<T> { Code = 500, Msg = ResponseEntity.FailedMsg };
        }
    }

    public class ResponseEntity
    {
        public string Msg { get; set; }
        public int Code { get; set; }
        
        public static string SuccessMsg = "success";
        public static string FailedMsg = "failed";

        public static ResponseEntity Success()
        {
            return new ResponseEntity { Code = 200, Msg = ResponseEntity.SuccessMsg };
        }

        public static ResponseEntity Failed()
        {
            return new ResponseEntity { Code = 500, Msg = ResponseEntity.FailedMsg };
        }

        public static ResponseEntity Failed(string msg)
        {
            return new ResponseEntity { Code = 500, Msg = msg };
        }
        public static ResponseEntity Failed(int code,string msg)
        {
            return new ResponseEntity { Code = code, Msg = msg };
        }

        public static ResponseEntity Success(string msg)
        {
            return new ResponseEntity { Code = 200, Msg = msg };
        }
    }
}