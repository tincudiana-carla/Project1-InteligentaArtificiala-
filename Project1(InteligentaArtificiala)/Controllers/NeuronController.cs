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
                    ViewBag.GINResult = NeuronViewModel.GIN;
                    break;
                case "prod":
                    string prodString = FunctionGIN.PROD(NeuronViewModel.Neurons);
                    NeuronViewModel.GIN = double.Parse(prodString);
                    ViewBag.GINResult = prodString;
                    break;
                case "max":
                    NeuronViewModel.GIN = FunctionGIN.MAX(NeuronViewModel.Neurons);
                    ViewBag.GINResult = NeuronViewModel.GIN;
                    break;
                case "min":
                    NeuronViewModel.GIN = FunctionGIN.MIN(NeuronViewModel.Neurons);
                    ViewBag.GINResult = NeuronViewModel.GIN;
                    break;
            }
            return View("Index", NeuronViewModel.Neurons);
        }

        [HttpPost]
        public IActionResult CalculateActivation(string function, double a, double g, double theta)
        {
            double gin = NeuronViewModel.GIN;
            double result;
            switch (function)
            {
                case "Step":
                    result = Activation.Step(gin);
                    NeuronViewModel.function = function;
                    break;

                case "Sigmoid":
                    result = Activation.Sigmoid(gin, g, theta);
                    NeuronViewModel.function = function;
                    break;

                case "Sign":
                    result = Activation.Sign(gin);
                    NeuronViewModel.function = function;
                    break;

                case "Tanh":
                    string decimalResult = Activation.Tanh(gin, g, theta);
                    NeuronViewModel.Activation = double.Parse(decimalResult);
                    result = NeuronViewModel.Activation;
                    NeuronViewModel.function = function;
                    break;

                case "LinearRamp":
                    result = Activation.LinearRamp(gin, a);
                    NeuronViewModel.function = function;
                    break;

                default:
                    result = 0;
                    break;
            }

            ViewBag.Activation = result;
            NeuronViewModel.Activation = result;
            NeuronViewModel.a = a;
            NeuronViewModel.g = g;
            NeuronViewModel.theta = theta;
            return View("Index", NeuronViewModel.Neurons);
        }
        [HttpPost]
        public IActionResult CalculateOutputResult()
        {
            double activation = NeuronViewModel.Activation;
            double result;
            string activationFunction = NeuronViewModel.function;
            switch (activationFunction)
            {
                case "Step":
                    result = OutputResult.OutputResult.Step(activation);
                    break;
                case "Sigmoid":
                    result = OutputResult.OutputResult.Sigmoid(activation);
                    break;
                case "Sign":
                    result = OutputResult.OutputResult.Sign(activation);
                    break;
                case "Tanh":
                    result = OutputResult.OutputResult.Tanh(activation);
                    break;
                case "LinearRamp":
                    result = OutputResult.OutputResult.LinearRamp(activation);
                    break;
                default:
                    result = 0; 
                    break;
            }

            NeuronViewModel.OutputResult = result;
            ViewBag.OutputResult = result;
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

        [HttpPost]
        public IActionResult ShowFloatOutputResult()
        {
            NeuronViewModel.OutputResult = NeuronViewModel.Activation;
            ViewBag.OutputResult = NeuronViewModel.OutputResult;
            return View("Index", NeuronViewModel.Neurons);
        }
    }

    
}
