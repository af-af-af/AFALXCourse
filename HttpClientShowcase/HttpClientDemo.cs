using HttpClientShowcase.Interfaces;
using HttpClientShowcase.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;

namespace HttpClientShowcase
{
    public class HttpClientDemo : IHttpClientDemo
    {
        private const string OutputFolderPath = @"C:\Temp\Img";
        private readonly HttpClient _httpClient;
        public HttpClientDemo(HttpClient client) 
        {
            _httpClient = client;
        }

        public async Task GetRandomJoke()
        {
            var requestUri = "https://official-joke-api.appspot.com/random_joke";
            var response = await _httpClient.GetAsync(requestUri);
            var responseContentJson = await response.Content.ReadAsStringAsync();
            var joke = JsonConvert.DeserializeObject<JokeResponse>(responseContentJson);
            Console.WriteLine($"Joke for today:\n{joke.Setup}\n -> {joke.Punchline}\n");
        }

        public async Task GetRandomCatInfo()
        {
            var requestUri = "https://catfact.ninja/fact";
            var response = await _httpClient.GetAsync(requestUri);
            var responseContentJson = await response.Content.ReadAsStringAsync();
            var catFact = JsonConvert.DeserializeObject<CatFactResponse>(responseContentJson);
            Console.WriteLine($"Fun fact about cats:\n{catFact.Fact}\n");
        }

        public async Task GetRandomDogImage()
        {
            var requestUri = "https://dog.ceo/api/breeds/image/random";
            var response = await _httpClient.GetAsync(requestUri);
            var responseContentJson = await response.Content.ReadAsStringAsync();
            var dogRandomImageResponse = JsonConvert.DeserializeObject<DogImageResponse>(responseContentJson);
            try
            {
                SaveImage(dogRandomImageResponse.Message, "something");
                Process.Start("explorer.exe", OutputFolderPath);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        public async Task PredictGender(string name)
        {
            var baseRequestUri = "https://api.genderize.io";
            var uriBuilder = new UriBuilder(baseRequestUri);
            uriBuilder.Query = $"name={name}";
            var uri = uriBuilder.Uri;
            var response = await _httpClient.GetAsync(uri);
            var responseContentJson = await response.Content.ReadAsStringAsync();
            var genderPreditionResponse = JsonConvert.DeserializeObject<GenderPredictionResponse>(responseContentJson);
            Console.WriteLine($"Name: {genderPreditionResponse.Name}\nGender: {genderPreditionResponse.Gender}" +
                $"\nProbability: {genderPreditionResponse.Probability*100}%\n");
        }

        public async Task SendEmail(Email email)
        {
            var baseRequestUri = "https://cnemailingservice20230203214349.azurewebsites.net/api/CNEMailingFunction";
            var requestJson = JsonConvert.SerializeObject(email); 
            var requestContent = new StringContent(requestJson);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, baseRequestUri);
            requestMessage.Content = requestContent;
            requestMessage.Headers.Add("x-functions-key", "<api key>");
            var result = await _httpClient.SendAsync(requestMessage);
            var resultContent = await result.Content.ReadAsStringAsync();
            Console.WriteLine(resultContent);
        }

        public async Task<string> Hello(string name)
        {
            return $"Hello {name}";
        }

        private void SaveImage(string imageUri, string fileName)
        {
            using (WebClient webClient = new WebClient())
            {
                var stream = webClient.OpenRead(imageUri);
                var bitmap = new Bitmap(stream);
                if(bitmap!=null)
                    bitmap.Save($"{OutputFolderPath}\\{fileName}.png", ImageFormat.Png);
            }
        }
    }
}
