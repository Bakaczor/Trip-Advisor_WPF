using System.Collections.ObjectModel;
using System.Windows;

namespace TripAdvisor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TouristAttraction> Attractions
        {
            get;
            set;
        }
        public MainWindow()
        {
            Attractions = new ObservableCollection<TouristAttraction>();
            InitializeComponent();
            Attractions.Add(new TouristAttraction()
            {
                Name = "Eiffel Tower",
                Localization = "Paris",
                OpeningDaysOfTheWeek = DayOfTheWeek.All,
                Free = false,
                Price = 10,
                Currency = Currency.EUR,
                Email = @"",
                PhoneNumber = @"",
                Website = @"https://www.toureiffel.paris/en",
                Notes = "",
                ImageName = @"EiffelTower.jpg"
            });
            Attractions.Add(new TouristAttraction()
            {
                Name="Himeji Castle",
                Localization = "Himeji City",
                OpeningDaysOfTheWeek = DayOfTheWeek.All ^ DayOfTheWeek.Monday,
                Free = false,
                Price = 1000,
                Currency = Currency.JPY,
                Email = @"",
                PhoneNumber = @"079-285-1146",
                Website = @"https://www.himejicastle.jp/en/",
                Notes = "",
                ImageName = @"HimejiCastle.jpg"
            });
            Attractions.Add(new TouristAttraction()
            {
                Name = "Meiji Shrine",
                Localization = "Tokyo",
                OpeningDaysOfTheWeek = DayOfTheWeek.Sunday | DayOfTheWeek.Monday | DayOfTheWeek.Tuesday,
                Free = true,
                PhoneNumber = @"03-3379-5511",
                Website = @"https://www.meijijingu.or.jp/en",
                Notes = "",
                ImageName = @"MeijiShrine.jpg"
            });
            Attractions.Add(new TouristAttraction()
            {
                Name = "Honkokuji Temple",
                Localization = "Kyoto",
                OpeningDaysOfTheWeek = DayOfTheWeek.Monday | DayOfTheWeek.Tuesday | DayOfTheWeek.Wednesday |DayOfTheWeek.Thursday |DayOfTheWeek.Friday | DayOfTheWeek.Saturday | DayOfTheWeek.Sunday,
                Currency = Currency.JPY,
                Free = false,
                Price = 500,
                Email = @"",
                PhoneNumber = @"",
                Website = @"",
                ImageName = "HonkokujiTemple.jpg",
                Notes = ""
            });
            Attractions.Add(new TouristAttraction()
            {
                Name = "Parthenon",
                Localization = "Athens",
                OpeningDaysOfTheWeek = DayOfTheWeek.All ^ DayOfTheWeek.Friday,
                Currency = Currency.EUR,
                Free = false,
                Price = 20,
                Email = @"info@thisisathens.org",
                PhoneNumber = "+30 210 331 2001",
                Website = @"https://www.thisisathens.org/antiquities/parthenon",
                ImageName = @"Parthenon.jpg",
                Notes = ""
            });
            DataContext = Attractions;
        }
    }
}
