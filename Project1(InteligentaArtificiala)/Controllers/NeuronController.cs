using Microsoft.AspNetCore.Mvc;
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
    }
}
