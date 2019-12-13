using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SustainableFarmingApp.Views
{
    public partial class Maps : ContentPage
    {
        public Maps()
        {
            InitializeComponent();

            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-33.933329, 18.6333308), Distance.FromMiles(10)));
        }
    }
}
