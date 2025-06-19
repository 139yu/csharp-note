namespace Siemens.Communication.Common
{
    public class SiemensResult
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public SiemensResult(bool status,string message)
        {
            this.Status = status;
            this.Message = message;
        }

        public static SiemensResult Success(bool status = true,string message = "ok")
        {
            return new SiemensResult(status, message);
        }
        
        public static SiemensResult Failed(string message = "error")
        {
            return new SiemensResult(false, message);
        }
    }
}