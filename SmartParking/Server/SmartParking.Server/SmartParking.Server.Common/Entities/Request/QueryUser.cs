using Microsoft.AspNetCore.Mvc;

namespace SmartParking.Server.Common.Entities.Request
{
    public class QueryUser: QueryPage
    {
        [FromQuery]
        public string Username { get; set; }
    }
}