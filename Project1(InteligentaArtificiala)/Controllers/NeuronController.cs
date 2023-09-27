using Microsoft.AspNetCore.Mvc;
using Project1_InteligentaArtificiala_.Activation_functions_;
using Project1_InteligentaArtificiala_.GeneratingGin;
using Project1_InteligentaArtificiala_.Models;

namespace Project1_InteligentaArtificiala_.Controllers
{
    public class NeuronController : Controller
    {
        public IActionResult Index()
        {
            return View(NeuronViewModel.Neurons);
        }

        [HttpPost]
        public IActionResult Add()
        {
            var viewModel = new NeuronViewModel(); 
            viewModel.AddNeuron();
            return View("Index", NeuronViewModel.Neurons);
        }

        [HttpPost]
        public IActionResult Subtract()
        {
            var viewModel = new NeuronViewModel(); 
            viewModel.SubtractNeuron();
            return View("Index", NeuronViewModel.Neurons);
        }

        public IActionResult Update(List<Input> inputs)
        {
            foreach (var updatedNeuron in inputs)
            {
                var existingNeuron = NeuronViewModel.Neurons.FirstOrDefault(n => n.Id == updatedNeuron.Id);

                if (existingNeuron != null)
                {
                    existingNeuron.x = updatedNeuron.x;
                    existingNeuron.w= updatedNeuron.w;
                }
            }
            return RedirectToAction("Index");
        }



        public IActionResult CalculateGIN(string operation)
        {
            switch (operation)
            {
                case "sum":
                    NeuronViewModel.GIN = FunctionGIN.SUM(NeuronViewModel.Neurons);
                    break;
                case "prod":
                    NeuronViewModel.GIN = FunctionGIN.PROD(NeuronViewModel.Neurons);
                    break;
                case "max":
                    NeuronViewModel.GIN = FunctionGIN.MAX(NeuronViewModel.Neurons);
                    break;
                case "min":
                    NeuronViewModel.GIN = FunctionGIN.MIN(NeuronViewModel.Neurons);
                    break;
            }
            ViewBag.GINResult = NeuronViewModel.GIN;
            return View("Index", NeuronViewModel.Neurons);
        }

        [HttpPost]
        public IActionResult CalculateActivation(string function, double a, double g, double theta)
        {
            double gin = NeuronViewModel.GIN;
            double result;
            double outputResult = NeuronViewModel.OutputResult;
            switch (function)
            {
                case "Step":
                    result = Activation.Step(gin);
                    outputResult = OutputResult.OutputResult.Step(result);
                    break;

                case "Sigmoid":
                    result = Activation.Sigmoid(gin, g, theta);
                    outputResult = OutputResult.OutputResult.Sigmoid(result);
                    break;

                case "Sign":
                    result = Activation.Sign(gin);
                    outputResult = OutputResult.OutputResult.Sign(result);
                    break;

                case "Tanh":
                    result = Activation.Tanh(gin, g, theta);
                    outputResult = OutputResult.OutputResult.Tanh(result);
                    break;

                case "LinearRamp":
                    result = Activation.LinearRamp(gin, a);
                    outputResult = OutputResult.OutputResult.LinearRamp(result);
                    break;

                default:
                    result = 0;
                    break;
            }

            ViewBag.Activation = result;
            ViewBag.OutputResult = outputResult;
            NeuronViewModel.Activation = result;
            NeuronViewModel.OutputResult = outputResult;
            NeuronViewModel.a = a;
            NeuronViewModel.g = g;
            NeuronViewModel.theta = theta;
            return View("Index", NeuronViewModel.Neurons);
        }
        [HttpPost]
        public IActionResult UpdateAGTheta(double a, double g, double theta)
        {
            NeuronViewModel.a = a;
            NeuronViewModel.g = g;
            NeuronViewModel.theta = theta;
            return RedirectToAction("Index"); 
        }
    }
}
