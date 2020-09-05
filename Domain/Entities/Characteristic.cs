using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Domain.Entities
{
    public class Characteristic
    {
        [Key]
        public int CharacteristicId { get; set; }

        public string Name { get; set; }
        
        public string CountOfPlayers { get; set; }

        public string RecommendAge { get; set; }
        public string Description { get; set; }
        public int TimeOfGame { get; set; }
        public int PurchaseId { get; set; }
        public int ManufacturerId { get; set; }
        public string Category { get; set; }
 
        public int Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
