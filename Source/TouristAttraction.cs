using System.Text;

namespace TripAdvisor
{
    public class TouristAttraction
    {
        public string Name
        {
            get;
            set;
        }

        public string ImageName
        {
            get;
            set;
        }
        
        public string Localization
        {
            get;
            set;
        }
        
        public DayOfTheWeek OpeningDaysOfTheWeek
        {
            get;
            set;
        }

        public bool Free
        {
            get;
            set;
        }

        public int? Price
        {
            get;
            set;
        }

        public Currency Currency
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }
        
        public string Email
        {
            get;
            set;
        }
        
        public string Website
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }
    }
}