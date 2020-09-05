
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;


namespace WebUI.Controllers
{
    public class CharacteristicController : Controller
    {
        private ICharacteristicRepository repository;
        public int pageSize = 4;
        public CharacteristicController(ICharacteristicRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, int page = 1)
        {
            CharacteristicListViewModel model = new CharacteristicListViewModel
            {
                Characteristics = repository.Characteristics
                    .OrderBy(characteristic => characteristic.CharacteristicId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {

                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
        repository.Characteristics.Count() :
        repository.Characteristics.Where(characteristic => characteristic.Category == category).Count()
                },
                  CurrentCategory = category
            };

            return View(model);
        }
        public FileContentResult GetImage(int characteristicId)
        {
            Characteristic characteristic = repository.Characteristics
                .FirstOrDefault(g => g.CharacteristicId == characteristicId);

            if (characteristic != null)
            {
                return File(characteristic.ImageData, characteristic.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}