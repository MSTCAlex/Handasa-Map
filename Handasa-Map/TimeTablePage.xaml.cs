using Handasa_Map.Common;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Handasa_Map.Helper;
using System.Collections.Generic;
using System.Linq;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Handasa_Map
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TimeTablePage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        private List<period> priodsData = new List<period>();

        public TimeTablePage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
            // set time table data Satardaylist
            string[] days = { "Saturday","Sunday","Monday","Tuesday","Wednesday","Thursday"};
            string[] priods = { "First", "Second", "Third", "Forth", "Fifth", "Sixth" };
            var saveTimeTable = new SaveTimeTable();


            ////test places
            //saveTimeTable.deletePriodData("Saturday", "First");
            //saveTimeTable.deletePriodData("Saturday", "Second");
            //saveTimeTable.deletePriodData("Sunday", "First");
            //saveTimeTable.deletePriodData("Monday", "First");
            //saveTimeTable.SaveValues("Saturday", "Second", "probability", "l5");
            //saveTimeTable.SaveValues("Sunday", "First", "modern", "l4");
            //saveTimeTable.SaveValues("Monday", "First", "programming", "l4");
            //saveTimeTable.SaveValues("Monday", "Second", "circuts", "l4");


            foreach (var day in days)
            {
                foreach (var priod in priods)
                {
                    var tableData = saveTimeTable.GetPriodData(day,priod);
                    if (tableData != null)
                    {
                        var period = new period();
                        period.Description = saveTimeTable.description(tableData);
                        period.Place = saveTimeTable.place(tableData);
                        period.Day = day;
                        period.Priod = priod;
                        priodsData.Add(period);
                    }
                }
            }


            // set list view source to priodsdata
            Satardaylist.ItemsSource = priodsData.Where(m => m.Day == days[0]).ToList();
            Sundaylist.ItemsSource = priodsData.Where(m => m.Day == days[1]).ToList();
            Mondaylist.ItemsSource = priodsData.Where(m => m.Day == days[2]).ToList();
            Tuesdaylist.ItemsSource = priodsData.Where(m => m.Day == days[3]).ToList();
            Wednesdaylist.ItemsSource = priodsData.Where(m => m.Day == days[4]).ToList();
            Thursdaylist.ItemsSource = priodsData.Where(m => m.Day == days[5]).ToList();




        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void Satardaylist_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (e.ClickedItem) as period;
            var place = clickedItem.Place;
            this.Frame.Navigate(typeof(Map), place);
        }

        private void EditAppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EditTimeTable));
        }
    }
}
