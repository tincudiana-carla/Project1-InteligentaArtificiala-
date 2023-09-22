using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;

namespace Project1_InteligentaArtificiala_.Models
{
    public class NeuronViewModel
    {
        public static List<Neuron> Neurons { get; private set; } = new List<Neuron>();
        public void AddNeuron()
        {
            Neurons.Add(new Neuron());
        }

        public void SubtractNeuron()
        {
            if (Neurons.Count > 0)
            {
                Neurons.RemoveAt(Neurons.Count - 1);
            }
        }
    }
}
