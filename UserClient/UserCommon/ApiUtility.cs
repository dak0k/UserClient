using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCommon
{
    public class ApiUtility
    {
        public const string URL = "http://alemkhan.somee.com/";

        public static async Task<string> GetApiResponseAsync(string route) // users
        {
           
            string responceContent;

            try
            {
                HttpClient httpClient = new HttpClient();

                HttpResponseMessage response = await httpClient.GetAsync(URL + route);

                if (response.IsSuccessStatusCode)
                {
                    responceContent = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    responceContent = null;
                }
            }
            catch
            {
                responceContent = null;
            }

            return responceContent;
        }
    }
}
