using System.Collections.Generic;

namespace DimensionTrip.Service.ViewModels.Internal
{
    public partial class CardPagedViewModel
    {
        public int Page { get; set; }
        public IList<CardViewModel> Cards { get; set; }
    }
}
