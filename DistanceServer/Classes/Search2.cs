using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceServer.Classes
{
    public class Search2
    {
        public int Id { get; set; }

        public Nullable<int> KodCitySource { get; set; }
        public Nullable<int> KodCityDestinision { get; set; }
        public Nullable<int> NumOfSearches { get; set; }
        public Nullable<double> distance { get; set; }
        public static Search2 convertSearch(Search search)
        {
            Search2 search2 = new Search2();
            search2.KodCitySource = search.KodCitySource;
            search2.Id = search.Id;
            search2.KodCityDestinision = search.KodCityDestinision;
            search2.NumOfSearches = search.NumOfSearches;
            search2.distance = search.distance;
            return search2;
        }
        public static List<Search2> convertListOfSearch(List<Search> search)
        {
            List<Search2> search2 = new List<Search2>();
            foreach (Search item in search)
            {
                search2.Add(convertSearch(item));
            }
            return search2;
        }
    }
}
