using PenguinServer.DB_Class;
using PenguinServer.Global_Methods;

namespace PenguinServer.Services
{
    public class YearSelectedControllerService
    {
        private readonly int _year;

        public YearSelectedControllerService(int year)
        {
            _year = year;
        }

        public List<PenguinData> GetYearSelectedData()
        {
            // FirstMethod --> To Get Bulk Data
            GetBulkData getBulkData = new GetBulkData();
            List<PenguinData> bulkData = getBulkData.ReadDataFile();

            // Second Method --> To Filter Data
            List<PenguinData> filteredData = FilterDataForYear(bulkData);

            return filteredData;
        }

        public List<PenguinData> FilterDataForYear(List<PenguinData> listToFilter)
        {
            //int targetYearFromFrontend = 2000; // Replace this with the actual value from the frontend

            var filteredData = listToFilter
                .GroupBy(p => p.SiteId)
                .Select(g =>
                {
                    var optionWithYear = g.FirstOrDefault(p => p.Year == _year);
                    if (optionWithYear != null)
                        return optionWithYear;

                    var optionClosestToTargetYear = g.OrderBy(p => Math.Abs(p.Year - _year)).FirstOrDefault();
                    if (optionClosestToTargetYear != null)
                        return optionClosestToTargetYear;

                    return g.OrderBy(p => Math.Abs(p.PenguinCount - g.Average(x => x.PenguinCount))).FirstOrDefault();
                })
                .ToList();
            return filteredData;
        }

    }
}
