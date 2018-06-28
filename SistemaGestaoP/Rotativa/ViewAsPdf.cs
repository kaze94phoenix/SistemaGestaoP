using System.Web.Mvc;
using SistemaGestaoP.Models;

namespace Rotativa
{
    internal class ViewAsPdf : ActionResult
    {
        private AvaliacaoViewModel model;
        private string v;

        public ViewAsPdf(string v, AvaliacaoViewModel model)
        {
            this.v = v;
            this.model = model;
        }

        public string FileName { get; set; }
    }
}