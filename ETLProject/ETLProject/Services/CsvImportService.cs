using CsvHelper;
using CsvHelper.Configuration;
using ETLProject.Data;
using System.Globalization;

namespace ETLProject.Services
{
    public class CsvImportService
    {
        private ApplicationDbContext _context;
        public CsvImportService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void ImportCsv(string csvFilePath)
        {
            if (string.IsNullOrEmpty(csvFilePath))
                throw new ArgumentException("CSV file path cannot be null or empty.", nameof(csvFilePath));

            try
            {
                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.Context.RegisterClassMap<MapTrip>();

                    var records = csv.GetRecords<Trip>().ToList();

                    var duplicates = records.GroupBy(x => new { x.PickupDateTime, x.DropoffDateTime, x.PassengerCount })
                                    .Where(g => g.Count() > 1)
                                    .SelectMany(g => g.Skip(1))
                                    .ToList();

                    WriteDuplicatesToCsv(duplicates);

                    records.RemoveAll(r => duplicates.Contains(r));

                    var easternTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

                    int batchSize = 1000;

                    for (int i = 0; i < records.Count; i += batchSize)
                    {
                        var batch = records.Skip(i).Take(batchSize).ToList();


                        foreach (var record in batch)
                        {
                            record.StoreAndFwdFlag = record.StoreAndFwdFlag.Trim();

                            if (record.StoreAndFwdFlag == "N")
                                record.StoreAndFwdFlag = "No";
                            else if (record.StoreAndFwdFlag == "Y")
                                record.StoreAndFwdFlag = "Yes";

                            record.PULocationID = record.PULocationID.Trim();
                            record.DOLocationID = record.DOLocationID.Trim();

                            record.PickupDateTime = TimeZoneInfo.ConvertTimeToUtc(record.PickupDateTime, easternTimeZone);
                            record.DropoffDateTime = TimeZoneInfo.ConvertTimeToUtc(record.DropoffDateTime, easternTimeZone);
                            _context.Add(record);

                        } 
                        _context.SaveChanges();
                        _context.Dispose();

                        _context = new ApplicationDbContext();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while importing CSV: {ex.Message}");
                throw;
            }
        }

        private void WriteDuplicatesToCsv(List<Trip> duplicates)
        {
            if (duplicates == null || duplicates.Count == 0)
                return;

            using (var writer = new StreamWriter("duplicates.csv"))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(duplicates);
            }
        }
    }
}
