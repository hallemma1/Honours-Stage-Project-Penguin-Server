using PenguinServer.DB_Class;
using PenguinServer.Global_Methods;

namespace PenguinServer.Services
{
    public class InitialMapStateControllerService
    {
        public List<PenguinData> GetInitialMapData()
        {
            // First Method --> To Get Bulk Data
            GetBulkData getBulkData = new GetBulkData();
            List<PenguinData> bulkData = getBulkData.ReadDataFile();

            // Second Method --> To Filter Data
            List<PenguinData> filteredData = FilterDataToInitial(bulkData);

            return filteredData;
        }
        public List<PenguinData> FilterDataToInitial(List<PenguinData> listToFilter)
        {
            var filteredData = listToFilter
                .GroupBy(p => p.SiteId)
                .Select(g => g.OrderByDescending(p => p.Year).ThenBy(p => Math.Abs(p.PenguinCount - g.Average(x => x.PenguinCount))).FirstOrDefault())
                .ToList();

            return filteredData;
        }

    }
}
