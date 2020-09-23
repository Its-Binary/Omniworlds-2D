using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class inventory
{
    [Test]
    public void only_allows_one_chest_to_be_equipped_at_a_time()
    {
        Inventory inventory = new Inventory();
        Item chestOne = new Item() {EquipSlot = EquipSlots.Chest};
        Item chestTwo = new Item() {EquipSlot = EquipSlots.Chest};
        
        inventory.EquipItem(chestOne);
        inventory.EquipItem(chestTwo);

        Item equippedItem = inventory.GetItem(EquipSlots.Chest);
        
        Assert.AreEqual(chestTwo,equippedItem);
    }
}
