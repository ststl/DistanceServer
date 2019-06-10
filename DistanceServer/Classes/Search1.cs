using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceServer
{
    partial class Search
    {
        public static void AddSearch(int kodSource, int kodDestination, double Kilometer)
        {
            using (CalculateDistanceEntities2 db = new CalculateDistanceEntities2())
            {
                Search search = new Search();
                search.KodCitySource = kodSource;
                search.KodCityDestinision = kodDestination;
                search.NumOfSearches = 1;
                search.distance = Kilometer;
                db.Search.Add(search);
                db.SaveChanges();
            }
        }

        public static bool CheckIfExistSearch(int source, int destination)
        {
            using (CalculateDistanceEntities2 db = new CalculateDistanceEntities2())
            {
                return db.Search.ToList().Exists(element => element.KodCitySource == source && element.KodCityDestinision == destination);
            }
        }

        public static double Update(int source, int destination)
        {
            using (CalculateDistanceEntities2 db = new CalculateDistanceEntities2())
            {
                Search search = new Search();
                search = db.Search.FirstOrDefault(searchelement => searchelement.KodCitySource == source &&
                searchelement.KodCityDestinision == destination);

                search.NumOfSearches += 1;
                db.SaveChanges();
                return (double)search.distance;
            }
        }
        public static List<Classes.Search2> GetPopularSearches()
        {
            using (CalculateDistanceEntities2 db = new CalculateDistanceEntities2())
            {
                return Classes.Search2.convertListOfSearch(db.Search.ToList().OrderByDescending(searchelement => searchelement.NumOfSearches).ToList());
            }
        }
        public static Classes.Search2 GetPopularSearch()
        {
            using (CalculateDistanceEntities2 db = new CalculateDistanceEntities2())
            {
                Classes.Search2 listSearch = Classes.Search2.convertSearch(db.Search.ToList().OrderByDescending(searchelement => searchelement.NumOfSearches).First());
                return listSearch;
            }
        }
    }
}
