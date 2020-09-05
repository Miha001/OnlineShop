
using System;
using Domain.Abstract;
using Domain.Entities;
using System.Linq;

namespace Domain.Concrete
{
 

    public class OrderProcessor : IOrderProcessor
    {
        EFDbContext EF = new EFDbContext();
        public void ProcessOrder(Cart cart, Orders o, UserData ud,Characteristic ch)
        {
            UserData newUD = new UserData();
            Orders newO = new Orders();
            GamesInOrders newGIO = new GamesInOrders();
            Purchase p = EF.FirstPrices
              .FirstOrDefault(g => g.PurchaseId == ch.CharacteristicId);
            //p.Count--;
            newGIO.CharacteristicsId = ch.CharacteristicId;
            newGIO.CountOfSoldGames = 1;
            newGIO.PriceOfSoldGame = 200;
            newUD.Addres = ud.Addres;
            newUD.FirstName = ud.FirstName;
            newUD.SecondName = ud.SecondName;
            newUD.MiddleName = ud.MiddleName;
            newO.UDId = newUD.UDId;
            newO.DateOfOrder = DateTime.Now;
            newO.StatusOfOrder = true;
            EF.GamesInOrders.Add(newGIO);
            EF.UserDatas.Add(newUD);
            EF.Orders.Add(newO);
            EF.SaveChanges();

        }
    }
}