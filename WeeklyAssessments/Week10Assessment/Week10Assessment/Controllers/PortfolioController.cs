using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week10Assessment.Models;



namespace Week10Assessment.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Asset> _assets = new List<Asset>();

        // expose assets for other controllers (read-only)
        public static IReadOnlyList<Asset> Assets => _assets;

        // GET: PortfolioController
        public ActionResult Index()
        {
            return View(_assets);
        }

        // GET: PortfolioController/Details/5
        [Route("Asset/Info/{id:int}")]
        public ActionResult Details(int id)
        {
            var detail = _assets.FirstOrDefault(x => x.AssetId == id);
            return View(detail);
        }

        // GET: PortfolioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortfolioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create(Asset asset)
        {
            _assets.Add(asset);
            return RedirectToAction(nameof(Index));
        }

        // GET: PortfolioController/Edit/5
        public ActionResult Edit(int id)
        {
            var editedId = _assets.FirstOrDefault(x => x.AssetId == id);
            return View(editedId);
        }

        // POST: PortfolioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Asset asset)
        {
            var editedId = _assets.FirstOrDefault(x => x.AssetId == id);
            editedId.AssetName = asset.AssetName;
            editedId.Quantity = asset.Quantity;
            editedId.Price = asset.Price;
            return RedirectToAction(nameof(Index));
        }

        // GET: PortfolioController/Delete/5
        public ActionResult Delete(int id)
        {
            var deletedId = _assets.FirstOrDefault(x => x.AssetId == id);
            return View(deletedId);
        }

        // POST: PortfolioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {           
           
            var deletedId = _assets.FirstOrDefault(x => x.AssetId == id);
            if(deletedId != null)
            {
                _assets.Remove(deletedId);
                TempData["Success"]= "Asset deleted successfully";
            }
            return RedirectToAction("Index");
           
        }
    }
}
