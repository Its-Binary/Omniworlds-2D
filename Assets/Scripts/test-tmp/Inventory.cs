using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class iInventory
{
    Dictionary<EquipSlots, Item> _equippedItems = new Dictionary<EquipSlots,Item>();
    private List<Item> _unequppiedItems = new List<Item>();

    public void EquipItem(Item item)
    {
        if (_equippedItems.ContainsKey(item.EquipSlot))
        {
            _unequppiedItems.Add(_equippedItems[item.EquipSlot]);
        }

        _equippedItems[item.EquipSlot] = item;
    }

    public Item GetItem(EquipSlots equipSlot)
    {
        if (_equippedItems.ContainsKey(equipSlot))
        {
            return _equippedItems[equipSlot];
        }

        return null;
    }

    public int GetTotalArmour()
    {
        int totalArmour = _equippedItems.Values.Sum(t => t.Armour);

        return totalArmour;
    }
}