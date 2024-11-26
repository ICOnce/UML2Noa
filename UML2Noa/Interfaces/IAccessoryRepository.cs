using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAccessoryRepository
{
    int Count { get;}
    List<Accessory> GetAll();
    void AddAccessory(Accessory accessory);
    Accessory GetAccessory(int id);
    void RemoveAccessory(int id);
    void PrintAllAccessories();
}

