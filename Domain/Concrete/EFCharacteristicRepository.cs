using System.Collections.Generic;
using Domain.Entities;
using Domain.Abstract;

namespace Domain.Concrete
{
    public class EFCharacteristicRepository:ICharacteristicRepository
    {
        EFDbContext context = new EFDbContext();


      

        public IEnumerable<Characteristic> Characteristics
        {
            get { return context.Characteristics; }
        }

        public void SaveGame(Characteristic characteristic)
        {
            
        

            if (characteristic.CharacteristicId == 0)
            {
                context.Characteristics.Add(characteristic);
            
                
            }
            else
            {  
                Characteristic dbEntry = context.Characteristics.Find(characteristic.CharacteristicId);
                
                if (dbEntry != null)
                {
                    dbEntry.Name = characteristic.Name;
                    dbEntry.Description = characteristic.Description;
                    dbEntry.Price = characteristic.Price;
                    dbEntry.Category = characteristic.Category;
                    dbEntry.RecommendAge = characteristic.RecommendAge;
                    dbEntry.TimeOfGame = characteristic.TimeOfGame;
                    dbEntry.CountOfPlayers = characteristic.CountOfPlayers;

                    dbEntry.ManufacturerId = characteristic.ManufacturerId;
                    dbEntry.PurchaseId = characteristic.PurchaseId;

                    dbEntry.ImageData = characteristic.ImageData;
                    dbEntry.ImageMimeType = characteristic.ImageMimeType;


                    //Проверить и Добавить оставшиеся

                }
            }
            context.SaveChanges();
        }

        public Characteristic DeleteGame(int characteristicId)
        {
            Characteristic dbEntry = context.Characteristics.Find(characteristicId);
            if (dbEntry != null)
            {
                context.Characteristics.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
