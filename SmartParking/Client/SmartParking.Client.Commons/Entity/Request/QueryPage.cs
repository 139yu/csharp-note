namespace SmartParking.Client.Commons.Entity.Request
{
    public class QueryPage
    {
        public int PageSize { get; set; } = 15;
        public int PageIndex { get; set; } = 1;
    }
}