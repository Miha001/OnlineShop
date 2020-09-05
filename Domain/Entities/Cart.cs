
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Characteristic characteristic, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Characteristic.CharacteristicId == characteristic.CharacteristicId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Characteristic = characteristic,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Characteristic characteristic)
        {
            lineCollection.RemoveAll(l => l.Characteristic.CharacteristicId == characteristic.CharacteristicId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Characteristic.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Characteristic Characteristic { get; set; }
        public int Quantity { get; set; }
    }
}