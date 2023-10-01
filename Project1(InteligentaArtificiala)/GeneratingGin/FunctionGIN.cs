using Project1_InteligentaArtificiala_.Models;

namespace Project1_InteligentaArtificiala_.GeneratingGin
{
    public class FunctionGIN
    {
        public static double SUM(List<Input> neurons)
        {
            double sum = 0.0;
            foreach (var neuron in neurons)
            {
                sum += neuron.x * neuron.w;
            }
            return sum;
        }

        public static string PROD(List<Input> neurons)
        {
            double prod = 1.0; 
            foreach (var neuron in neurons)
            {
                prod *= neuron.x * neuron.w;
            }
            return prod.ToString("0.0000000000000000");
        }

        public static double MAX(List<Input> neurons)
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

        public static double MIN(List<Input> neurons)
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
