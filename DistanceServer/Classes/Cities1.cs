using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DistanceServer
{
    partial class Cities
    {
        public static void AddCity(string NameCity)
        {

            using (CalculateDistanceEntities2 db = new CalculateDistanceEntities2())
            {
               if (db.Cities.ToList().Exists(a=>a.NameCity==NameCity)==false)
               {
                Cities city = new Cities();
                city.NameCity = NameCity;
                db.Cities.Add(city);
                    try
                    {
                        db.SaveChanges();

                    }
                    catch 
                    {
                    }
               }
               
            }
        }
        public static List<Cities2> GetListCities()
        {
            using (CalculateDistanceEntities2 db = new CalculateDistanceEntities2())
            {
                return Cities2.ConvertCities(db.Cities.ToList());
            }
        }
        public static string GetNameCity(int id)
        {
            using (CalculateDistanceEntities2 db = new CalculateDistanceEntities2())
            {
                return db.Cities.FirstOrDefault(city => city.id == id).NameCity;
            }
        }
    
        }
    }
  
