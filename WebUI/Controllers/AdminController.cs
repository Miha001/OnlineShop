using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using System.Web;
using Domain.Concrete;
using System.Collections.Generic;

namespace WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        EFDbContext EF = new EFDbContext();
        ICharacteristicRepository repository;

        public AdminController(ICharacteristicRepository repo)
        {
            repository = repo;
        }
        public ActionResult Orders()
        {
            IEnumerable<Orders> orders = EF.Orders;
            IEnumerable<UserData> userdatas = EF.UserDatas;

            ViewBag.Orders = orders;
            ViewBag.UserDatas = userdatas;

            return View();
        }

        public ViewResult Index()
        {
            //Извлекаем данные из колекций        
            IEnumerable<Characteristic> characteristics = EF.Characteristics;        
            IEnumerable<Purchase> firstPrices = EF.FirstPrices;
           

            ViewBag.Characteristics = characteristics;      
            ViewBag.FirstPrices = firstPrices;

           

            return View();
        }
        public ViewResult Create()
        {
            return View("Edit", new Characteristic());
        }

    public ViewResult Edit(int characteristicId)
        {
            Characteristic characteristic = repository.Characteristics
                .FirstOrDefault(g => g.CharacteristicId == characteristicId);
            return View(characteristic);
        }

        [HttpPost]
        public ActionResult Edit(Purchase p,Characteristic ch, HttpPostedFileBase image = null)
        {
            Purchase newP = new Purchase();

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    ch.ImageMimeType = image.ContentType;
                    ch.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(ch.ImageData, 0, image.ContentLength);
                    newP.Count = 10;
                    newP.Price = ch.Price;
                }
                repository.SaveGame(ch);
                TempData["message"] = string.Format("Изменения в игре \"{0}\" были сохранены", ch.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(ch);
            }
        }
        [HttpPost]
        public ActionResult Delete(int characteristicId)
        {
            Characteristic deletedGame = repository.DeleteGame(characteristicId);
            if (deletedGame != null)
            {
                TempData["message"] = string.Format("Игра \"{0}\" была удалена",
                    deletedGame.Name);
            }
            return RedirectToAction("Index");
        }

       

    }
}