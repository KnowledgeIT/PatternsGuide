using System.Collections.Generic;

namespace DimensionTrip.Service.ViewModels.Internal
{
    public partial class DimensionPagedViewModel
    {
        public int Page { get; set; }
        public IList<DimensionViewModel> Dimensions { get; set; }
    }
}
