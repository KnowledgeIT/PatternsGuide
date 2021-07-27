using System.Collections.Generic;

namespace DimensionTrip.Service.ViewModels.Internal
{
    public partial class CharacterPagedViewModel
    {
        public int Page { get; set; }
        public IList<CharacterViewModel> Characters { get; set; }
    }
}
