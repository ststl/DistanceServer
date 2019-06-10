using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceServer
{
    public class Cities2
    {
        public int id { get; set; }
        public string NameCity { get; set; }

        public static Cities2 ConvertCity(Cities city)
        {
            Cities2 city1 = new Cities2();
            city1.id = city.id;
            city1.NameCity = city.NameCity;
            return city1;
        }

        internal static List<Cities2> ConvertCities(List<Cities> list)
        {
            List<Cities2> listcities = new List<Cities2>();
            foreach (Cities item in list)
            {
                listcities.Add(ConvertCity(item));
            }
            return listcities;
        }
    }
}
