namespace plattform_partizipatives_neophytenmanagement.Services
{

    public class CreateHelperHelpOfferDto
    {
        public int OwnerId { get; set; }

        public string Location { get; set; }

        public double DistanceFromLocation { get; set; }

        public int WorkVolume { get; set; }

        public int NumberOfHelpers { get; set; }
    }

    public class FilterHelperHelpOfferDto
    {
        public int WorkVolume { get; set; }
        public int NumberOfHelpers { get; set; }
    }

    public class HelperHelpOfferService
    {

    }
}