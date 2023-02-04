using HttpClientShowcase;
using HttpClientShowcase.Models;

Console.WriteLine("Http Client demo...\n");
var serializationDemo = new SerializationDemo();
//var jsonStrings = serializationDemo.RunSerialization();
//serializationDemo.RunDeserialization(jsonStrings);
var client = new HttpClient();
var httpClientDemo = new HttpClientDemo(client);
//var hello = await httpClientDemo.Hello("Mateusz");
//Console.WriteLine(hello);*/
await httpClientDemo.GetRandomJoke();
await httpClientDemo.GetRandomCatInfo();
await httpClientDemo.GetRandomDogImage();
await httpClientDemo.PredictGender("Ala");

var email = new Email
{
    To = "",
    Subject = "App test",
    Message = "Alx course app sends regards O.o"
};
await httpClientDemo.SendEmail(email);
