using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
namespace datacapture.services
{
    public class Serverservice
    {
        public string url = "http://localhost:5054";
        public Serverservice() { }
        public async void uploaddata(byte[] _imageData, FileResult _imageFile)
        {
           string fullurl = url + "/api/login";
            using var content = new MultipartFormDataContent();
           using var stream = await _imageFile.OpenReadAsync();
           var fileContent = new StreamContent(stream);
           fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

           content.Add(fileContent, "file", _imageFile.FileName);

           using var client = new HttpClient();
           var response = await client.PostAsync("https://yourserver.com/api/upload", content);

          
           
        }
        public async Task<string> LoginAsync(string username, string password)
        {
            string fullurl = url + "/api/User/login";
            using var client = new HttpClient();
            

            var requestBody = new
            {
                Username = username,
                PasswordHash = password // Or plain password if you're hashing server-side
            };

            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync(fullurl, content);

            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<getdata>(responseString);
                return ( result.status);
            }
            else
            {
                var failResult = JsonSerializer.Deserialize<getdata>(responseString);
                return ("fail");
            }
        }
        public class getdata
        {
            public string status { get;set; }
        }
        // Helper classes for deserialization
       

    }


}
