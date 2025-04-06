using System.Net.Http.Headers;
namespace datacapture.services
{
    public class Serverservice
    {
        public string Name = "https://yourserver.com/api/upload";
        public Serverservice() { }
        public async void uploaddata(byte[] _imageData, FileResult _imageFile)
        {
           
           using var content = new MultipartFormDataContent();
           using var stream = await _imageFile.OpenReadAsync();
           var fileContent = new StreamContent(stream);
           fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

           content.Add(fileContent, "file", _imageFile.FileName);

           using var client = new HttpClient();
           var response = await client.PostAsync("https://yourserver.com/api/upload", content);

          
           
        }
    }

    
}
