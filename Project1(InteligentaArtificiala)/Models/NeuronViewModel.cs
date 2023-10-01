using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;

namespace Project1_InteligentaArtificiala_.Models
{
    public class NeuronViewModel
    {
        public static List<Input> Neurons { get; set; } = new List<Input>() { new Input {Id = 0 , x = 0.0, w = 0.0 } };
        public static double GIN { get; set; }
        public static double Activation { get; set; }
        public static double g = 1;
        public static double a = 1;
        public static double theta = 0;
        public static string function;

        private static int currentId = 0;
        public static double OutputResult { get; set; }

        public void AddNeuron()
        {
            Neurons.Add(new Input {Id = ++currentId , x=0.0, w=0.0});
        }
        public void SubtractNeuron()
        {
            if (Neurons.Count > 1)
            {
                Neurons.RemoveAt(Neurons.Count - 1);
            }
        }
    }
}
