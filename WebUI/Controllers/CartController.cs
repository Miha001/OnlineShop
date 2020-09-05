using System.Linq;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Abstract;
using WebUI.Models;

namespace GameStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private ICharacteristicRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(ICharacteristicRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int characteristicId, string returnUrl)
        {
            Characteristic characteristic = repository.Characteristics
                .FirstOrDefault(g => g.CharacteristicId == characteristicId);

            if (characteristic != null)
            {
                cart.AddItem(characteristic, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int characteristicId, string returnUrl)
        {
            Characteristic characteristic = repository.Characteristics
                .FirstOrDefault(g => g.CharacteristicId == characteristicId);

            if (characteristic != null)
            {
                cart.RemoveLine(characteristic);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }


        public ViewResult Checkout()
        {
            return View(new UserData());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, Orders o, UserData ud, Characteristic ch)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart,o, ud,ch);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(ud);
            }
        }


    }
}