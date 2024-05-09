using CsvHelper.Configuration;

namespace ETLProject.Services
{
    public class MapTrip : ClassMap<Trip>
    {
        public MapTrip()
        {
            Map(m => m.PickupDateTime).Name("tpep_pickup_datetime");
            Map(m => m.DropoffDateTime).Name("tpep_dropoff_datetime");
            Map(m => m.PassengerCount).Name("passenger_count");
            Map(m => m.TripDistance).Name("trip_distance");
            Map(m => m.StoreAndFwdFlag).Name("store_and_fwd_flag");
            Map(m => m.PULocationID).Name("PULocationID");
            Map(m => m.DOLocationID).Name("DOLocationID");
            Map(m => m.FareAmount).Name("fare_amount");
            Map(m => m.TipAmount).Name("tip_amount");
        }
    }
}
