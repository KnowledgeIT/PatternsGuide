using System;

namespace Sales.Model.Models.Interfaces.Base
{
    public interface IBaseDto
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
