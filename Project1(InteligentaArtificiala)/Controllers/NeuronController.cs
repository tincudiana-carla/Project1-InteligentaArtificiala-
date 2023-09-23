using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
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
            double ginResult = 0.0;
            switch (operation)
            {
                case "sum":
                    ginResult = FunctionGIN.SUM(NeuronViewModel.Neurons);
                    break;
                case "product":
                    ginResult = FunctionGIN.PROD(NeuronViewModel.Neurons);
                    break;
                case "max":
                    ginResult = FunctionGIN.MAX(NeuronViewModel.Neurons);
                    break;
                case "min":
                    ginResult = FunctionGIN.MIN(NeuronViewModel.Neurons);
                    break;
            }
            ViewBag.GINResult = ginResult;
            return View("Index", NeuronViewModel.Neurons);
        }
    }
}
