using Microsoft.AspNetCore.Mvc;

namespace SmartParking.Server.Common.Entities.Request
{
    public class QueryPage
    {

        [FromQuery] public int PageSize { get; set; } = 15;

        [FromQuery] public int PageIndex { get; set; } = 1;
    }
}