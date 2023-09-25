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

        public IActionResult Update(int index, double x, double w)
        {
            if (index >= 0 && index < NeuronViewModel.Neurons.Count)
            {
                NeuronViewModel.Neurons[index].x = x;
                NeuronViewModel.Neurons[index].w = w;
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

        //[HttpPost]
        //public IActionResult CalculateOutputResult(string functionName)
        //{
        //    double result = 0;
        //    switch(functionName)
        //    {
        //        case "Step":
        //            result = OutputResult.OutputResult.Step();
        //            break;
        //        case "Sigmoid":
        //            result = OutputResult.OutputResult.Sigmoid();
        //            break;
        //        case "Sign":
        //            result = OutputResult.OutputResult.Sign();
        //            break;
        //        case "Tanh":
        //            result = OutputResult.OutputResult.Tanh();
        //            break;
        //        case "LinearRamp":
        //            result = OutputResult.OutputResult.LinearRamp();
        //            break;
        //    }
        //    ViewBag.FunctionName = functionName;
        //    ViewBag.OutputResult = result;
        //    NeuronViewModel.OutputResult = result;
        //    return View();
        //}

    }
}
