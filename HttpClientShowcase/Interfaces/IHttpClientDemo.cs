using HttpClientShowcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientShowcase.Interfaces
{
    public interface IHttpClientDemo
    {
        Task GetRandomJoke();
        Task GetRandomCatInfo();
        Task GetRandomDogImage();
        Task PredictGender(string name);
        Task SendEmail(Email email);
    }
}
