using ETLProject.Data;
using ETLProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TripsDB;Trusted_Connection=True;")
    )
    .AddScoped<CsvImportService>()
    .BuildServiceProvider();

string csvFilePath = "C:\\Users\\Andriy\\Desktop\\cabdata.csv";

var csvImportService = serviceProvider.GetService<CsvImportService>();

if (csvImportService != null)
{
    csvImportService.ImportCsv(csvFilePath);
}

