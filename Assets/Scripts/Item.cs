using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")] //This is to create a "section" inside unity to seperate areas out for readability
    public bool isItem;
    public bool isWeapon;
    public bool isArmour;

    [Header("Item Details")] 
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;

    [Header("Item Details")] 
    public int amountToChange;
    public bool affectHp;
    public bool affectMp;
    public bool affectStr;

    [Header("Weapon/Armour Details")] 
    public int weaponStrength;
    public int armourStrength;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use(int targetCharacter)
    {
        CharStats selectedCharacter = GameManager.instance.playerStats[targetCharacter];

        if (isItem)
        {
            if (affectHp)
            {
                selectedCharacter.currentHp += amountToChange;

                if (selectedCharacter.currentHp > selectedCharacter.maxHp)
                {
                    selectedCharacter.currentHp = selectedCharacter.maxHp;
                }
            } 
            else if (affectMp)
            {
                selectedCharacter.currentMp += amountToChange;

                if (selectedCharacter.currentMp > selectedCharacter.maxMp)
                {
                    selectedCharacter.currentMp = selectedCharacter.maxMp;
                }
            } 
            else if (affectStr)
            {
                selectedCharacter.strength += amountToChange;
            }
        }
        
        if(isWeapon)
        {
            if(selectedCharacter.equippedWpn != "")
            {
                GameManager.instance.AddItem(selectedCharacter.equippedWpn);
            }

            selectedCharacter.equippedWpn = itemName;
            selectedCharacter.wpnPower = weaponStrength;
        }

        if(isArmour)
        {
            if (selectedCharacter.equippedArmour != "")
            {
                GameManager.instance.AddItem(selectedCharacter.equippedArmour);
            }

            selectedCharacter.equippedArmour = itemName;
            selectedCharacter.armourPwr = armourStrength;
        }

        GameManager.instance.RemoveItem(itemName);
    }
}
