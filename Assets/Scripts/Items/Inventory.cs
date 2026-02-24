using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public uint MaxCapacity { get; private set; } = 10;
    [SerializeField] SerializableDictionary<ItemSO, uint> InventoryData = new();
    public uint TryAddItem(ItemSO item, uint amount)
    {
        if (InventoryData.TryGetValue(item, out uint value))
        {
            if (value + amount > MaxCapacity)
            {
                uint difference = value + amount - MaxCapacity;
                InventoryData[item] = MaxCapacity;
                return difference;
            }
            InventoryData[item] += amount;
            return 0;
        }
        InventoryData.Add(item, amount > MaxCapacity ? MaxCapacity : amount);
        return amount > MaxCapacity ? amount - MaxCapacity : 0;
    }
}
