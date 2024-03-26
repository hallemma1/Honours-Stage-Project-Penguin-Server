using PenguinServer.DB_Class;
using PenguinServer.Global_Methods;

namespace PenguinServer.Services
{
    public class CarbonEmissionsChangeControllerService
    {
        public List<PenguinData> GetCarbonEmissionsAlteredData()
        {
            // FirstMethod --> To Get Bulk Data
            GetBulkData getBulkData = new GetBulkData();
            List<PenguinData> bulkData = getBulkData.ReadDataFile();

            // Second Method --> To Alter Data
            List<PenguinData> filteredData = AlterDataCarbonEmissionsChange(bulkData);

            return filteredData;
        }

        public List<PenguinData> AlterDataCarbonEmissionsChange(List<PenguinData> bulkData)
        {
            int targetYearFromFrontend = 2024;
            //.Select(g => g.OrderByDescending(p => p.Year).ThenBy(p => Math.Abs(p.PenguinCount - g.Average(x => x.PenguinCount))).FirstOrDefault())
            var filteredData = bulkData
                .GroupBy(p => p.SiteId)
                .Select(g =>
                {
                    var optionWithYear = g.FirstOrDefault(p => p.Year == targetYearFromFrontend);
                    if (optionWithYear != null)
                        return optionWithYear;

                    var optionClosestToTargetYear = g.OrderBy(p => Math.Abs(p.Year - targetYearFromFrontend)).FirstOrDefault();
                    if (optionClosestToTargetYear != null)
                        return optionClosestToTargetYear;

                    return g.OrderBy(p => Math.Abs(p.PenguinCount - g.Average(x => x.PenguinCount))).FirstOrDefault();
                })
                .Select(p => new PenguinData
                {
                    SiteName = p.SiteName,
                    SiteId = p.SiteId,
                    Longitude = p.Longitude,
                    Latitude = p.Latitude,
                    CommonName = p.CommonName,
                    Year = p.Year,
                    PenguinCount = (int)Math.Round(p.PenguinCount * 1.25) // Increase by 25%
                })
                .ToList();

            return filteredData;

        }

    }
}
