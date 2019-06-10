using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceServer
{
    public class GetDistance
    {

        public static string fileGetContents(string fileName)
        {
            string sContents = string.Empty;
            string me = string.Empty;

            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] response = wc.DownloadData(fileName);
            sContents = System.Text.Encoding.ASCII.GetString(response);

            return sContents;
        }
      
    }
}