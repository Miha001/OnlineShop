using Domain.Entities;
using System.Collections.Generic;


namespace Domain.Abstract
{
    public interface ICharacteristicRepository
    {
        IEnumerable<Characteristic> Characteristics { get; }
        void SaveGame(Characteristic characteristic);
        Characteristic DeleteGame(int characteristicId);
    }
}
