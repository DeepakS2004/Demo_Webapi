using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Unicode;


namespace Demo_Webapi
{
    public static class Helper
    {

        public static string Baseurl = "https://demoapijs.azurewebsites.net";
        public static string geturl = Baseurl + "/api/Std/GetData";
        public static string posturl = Baseurl + "/api/Std/Savedata";
        public static string editurl = Baseurl + "/api/Std/Editdata";
        public static async Task<List<Student>> Getdata()
        {
            List<Student> data = new List<Student>();
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    HttpResponseMessage response = await client.GetAsync(geturl);
                    response.EnsureSuccessStatusCode();
                    string result = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<Student>>(result);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"error: {ex.Message}");
                }
                return data;
            }
        }
        public static async Task<bool> Postdata(Student value)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string postvalue = JsonConvert.SerializeObject(value);
                    HttpResponseMessage response = await client.PostAsync(posturl, new StringContent(postvalue, Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();
                    string responsebody = await response.Content.ReadAsStringAsync();
                    var responcedata = JsonConvert.DeserializeObject<Student>(responsebody);
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
            return true;
        }

        
        
    }
}
