using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShaumStore.Domain.Abstract;
using ShaumStore.Domain.Entities;
using ShaumStore.WebUI.Models;

namespace ShaumStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        public CartController (IProductRepository repo)
        {
            repository = repo;
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public RedirectToRouteResult AddToCart(int productID, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault
                                                (p => p.ProductID == productID);
            if(product != null)
            {
                GetCart().AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault
                                                    (p => p.ProductID == productId);
            if(product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
    }
}