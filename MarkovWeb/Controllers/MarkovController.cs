using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Markov;
using MarkovWeb.Models;

namespace MarkovWeb.Controllers
{
    public class MarkovController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            MarkovChain markovChain = new MarkovChain();
            return View(markovChain);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(MarkovChain markovChain)
        {
            markovChain.OutputLength = 2000;

            var stringBuilder = new StringBuilder();

            var seed = markovChain.SourceText.Tokenize();
            var chain = new Chain<string>(seed, 3);
            if(string.IsNullOrEmpty(markovChain.StartWord))
            {
                chain.Generate(markovChain.OutputLength).ForEach(word => stringBuilder.Append(word));
            }
            else
            {
                chain.Generate(markovChain.StartWord, markovChain.OutputLength).ForEach(word => stringBuilder.Append(word));
            }

            TempData["output"] = stringBuilder.ToString();
            return RedirectToAction("Display");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Display()
        {
            return View();
        }
    }
}
