using System.ComponentModel.DataAnnotations;

namespace Sales.Service.Enums
{
    public class ServiceEnums
    {
        public enum EndPointActionType
        {
            [Display(Name = "GET")]
            GET = 0,
            [Display(Name = "GETLIST")]
            GETLIST = 1,
            [Display(Name = "POST")]
            POST = 2,
            [Display(Name = "PUT")]
            PUT = 3,
            [Display(Name = "DELETE")]
            DELETE = 4
        }
    }
}
