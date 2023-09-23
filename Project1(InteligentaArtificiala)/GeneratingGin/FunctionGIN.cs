using Project1_InteligentaArtificiala_.Models;

namespace Project1_InteligentaArtificiala_.GeneratingGin
{
    public class FunctionGIN
    {
        public static double SUM(List<Neuron> neurons)
        {
            double sum = 0.0;
            foreach (var neuron in neurons)
            {
                sum += neuron.x * neuron.w;
            }
            return sum;
        }

        public static double PROD(List<Neuron> neurons)
        {
            double prod = 1.0; 
            foreach (var neuron in neurons)
            {
                prod *= neuron.x * neuron.w;
            }
            return prod;
        }

        public static double MAX(List<Neuron> neurons)
        {
            double maxValue = double.MinValue;
            foreach (var neuron in neurons)
            {
                double value = neuron.x * neuron.w;
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }
            return maxValue;
        }

        public static double MIN(List<Neuron> neurons)
        {
            double minValue = double.MaxValue;
            foreach (var neuron in neurons)
            {
                double value = neuron.x * neuron.w;
                if (value < minValue)
                {
                    minValue = value;
                }
            }
            return minValue;
        }

    }
}
