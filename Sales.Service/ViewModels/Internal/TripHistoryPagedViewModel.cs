using System.Collections.Generic;

namespace DimensionTrip.Service.ViewModels.Internal
{
    public partial class TripHistoryPagedViewModel
    {
        public int Page { get; set; }
        public IList<TripHistoryViewModel> Trips { get; set; }
    }
}
