using Project1_InteligentaArtificiala_.Activation_functions_;
using Project1_InteligentaArtificiala_.Models;

namespace Project1_InteligentaArtificiala_.OutputResult
{
    public class OutputResult
    {
        public static double Step(double activation) //treapta
        {
            activation = NeuronViewModel.Activation;
            return activation;
        }
        public static double Sigmoid(double activation) //sigmoid
        {
            if (activation >= 0.5)
                return 1;
            else return 0;
        }
        public static double Sign(double activation) //semn
        {
            activation = NeuronViewModel.Activation;
            return activation;
        }
        public static double Tanh(double activation) //tangenta hiperbolica
        {
            activation = NeuronViewModel.Activation;
            if (activation >= 0)
                return 1;
            return -1;
        }
        public static double LinearRamp(double activation) //rampa(functia liniara)
        {
            activation = NeuronViewModel.Activation;
            if (activation >= 0)
                return 1;
            return -1;
        }
    }
}
