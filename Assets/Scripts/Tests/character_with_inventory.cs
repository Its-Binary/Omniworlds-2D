using NSubstitute;
using NUnit.Framework;

public class character_with_inventory
{
    [Test]
    public void with_90_armour_takes_10_percent_damage()
    {
        ICharacter character = Substitute.For<ICharacter>();
        Inventory inventory = new Inventory();
        Item legItem = new Item() {EquipSlot = EquipSlots.Legs, Armour = 40};
        Item shield = new Item() {EquipSlot = EquipSlots.RightHand, Armour = 50};
        
        inventory.EquipItem(legItem);
        inventory.EquipItem(shield);

        character.Inventory.Returns(inventory);

        int calculatedDamage = DamageCalculator.CalculateDamage(100, character);
        
        Assert.AreEqual(10, calculatedDamage);
    }
}