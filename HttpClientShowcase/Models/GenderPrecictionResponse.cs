using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientShowcase.Models
{

    public class GenderPredictionResponse
    {
        public int Count { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public float Probability { get; set; }
    }

}
