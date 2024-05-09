namespace ETLProject
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime PickupDateTime { get; set; }
        public DateTime DropoffDateTime { get; set; }
        public int? PassengerCount { get; set; }
        public double TripDistance { get; set; }
        public string StoreAndFwdFlag { get; set; }
        public string PULocationID { get; set; }
        public string DOLocationID { get; set; }
        public double FareAmount { get; set; }
        public double TipAmount { get; set; }
    }
}
