using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public static GameMenu instance;
    
    public GameObject menu;
    public GameObject[] windows;
    
    private CharStats[] playerStats;
    public Text[] nameText;
    public Text[] hpText;
    public Text[] mpText;
    public Text[] lvlText;
    public Text[] xpText;
    public Slider[] xpSlider;
    public Image[] charImage;
    public GameObject[] statHolder;
    public GameObject[] statusButtons;
    public Text goldText;

    public Text statusName;
    public Text statusHp;
    public Text statusMp;
    public Text statusXp;
    public Text statusStrength;
    public Text statusDefence;
    public Text statusWpnEquip;
    public Text statusWpnPwr;
    public Text statusArmourEquip;
    public Text statusArmourPwr;
    public Image statusImage;
    
    public ItemButton[] itemButtons;
    public string selectedItem;
    public Item activeItem;
    public Text itemName;
    public Text itemDescription;
    public Text useButtonText;
    public GameObject itemCharChoiceMenu;
    public Text[] itemCharChoiceNames;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Temp button use for menu
        if (Input.GetButtonDown("Fire2"))
        {
            //check if menu is open
            if (menu.activeInHierarchy)
            {
                CloseMenu();
            }
            else
            {
                menu.SetActive(true);
                UpdateMainStats();
                
                GameManager.instance.gameMenuOpen = true;
            }
        }
    }

    public void UpdateMainStats()
    {
        //Lets get the actual valid stats
        playerStats = GameManager.instance.playerStats;
        
        //Lets update the menu UI values
        for (int i = 0; i < playerStats.Length; i++)
        {
            //check to see if slot is being used and show/hide holder
            if (playerStats[i].gameObject.activeInHierarchy)
            {
                statHolder[i].SetActive(true);

                nameText[i].text = playerStats[i].charName;
                hpText[i].text = $"HP: {playerStats[i].currentHp} / {playerStats[i].maxHp}";
                mpText[i].text = $"MP: {playerStats[i].currentMp} / {playerStats[i].maxMp}";
                lvlText[i].text = $"Lvl: {playerStats[i].playerLevel}";
                xpText[i].text = $"{playerStats[i].currentXP}/{playerStats[i].xpToNextLevel[playerStats[i].playerLevel]}";
                xpSlider[i].maxValue = playerStats[i].xpToNextLevel[playerStats[i].playerLevel];
                xpSlider[i].value = playerStats[i].currentXP;
                charImage[i].sprite = playerStats[i].charImage;
            }
            else
            {
                statHolder[i].SetActive(false);
            }
        }

        goldText.text = GameManager.instance.currentGold.ToString() + "g";
    }

    public void ToggleWindow(int windowNumber)
    {
        UpdateMainStats();
        
        //Loop through available windows
        for (int i = 0; i < windows.Length; i++)
        {
            if (i == windowNumber)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
        
        itemCharChoiceMenu.SetActive(false);
    }

    public void CloseMenu()
    {
        //Loop through and make sure all windows are closed
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }
        
        //now close down the menu
        menu.SetActive(false);

        //make sure the player is allowed to move
        GameManager.instance.gameMenuOpen = false;

        itemCharChoiceMenu.SetActive(false);
    }

    public void OpenStatus()
    {
        //Update the info that is shown
        UpdateMainStats();
        CharacterStatus(0);
        
        //Update the P buttons
        for (int i = 0; i < statusButtons.Length; i++)
        {
            statusButtons[i].SetActive(playerStats[i].gameObject.activeInHierarchy);
            statusButtons[i].GetComponentInChildren<Text>().text = playerStats[i].charName; // set the button text
        }
    }

    public void CharacterStatus(int selected)
    {
        //Update the character stats
        statusName.text = playerStats[selected].charName;
        statusHp.text = $"{playerStats[selected].currentHp}/{playerStats[selected].maxHp}";
        statusMp.text = $"{playerStats[selected].currentMp}/{playerStats[selected].maxMp}";
        statusDefence.text = $"{playerStats[selected].defence}";
        statusStrength.text = $"{playerStats[selected].strength}";
        statusImage.sprite = playerStats[selected].charImage;
        statusArmourEquip.text = (playerStats[selected].equippedArmour != "") ? playerStats[selected].equippedArmour : "None";
        statusArmourPwr.text = $"{playerStats[selected].armourPwr}";
        statusWpnEquip.text = (playerStats[selected].equippedWpn != "") ? playerStats[selected].equippedWpn : "None";
        statusXp.text = $"{(playerStats[selected].xpToNextLevel[playerStats[selected].playerLevel] - playerStats[selected].currentXP)}";
    }

    public void ShowItems()
    {
        GameManager.instance.SortItems();

        for(int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].buttonValue = i;

            if(GameManager.instance.itemsHeld[i] != "")
            {
                itemButtons[i].buttonImage.gameObject.SetActive(true);
                itemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[i]).itemSprite;
                itemButtons[i].amountText.text = GameManager.instance.numberOfItems[i].ToString();
            } else
            {
                itemButtons[i].buttonImage.gameObject.SetActive(false);
                itemButtons[i].amountText.text = "";
            }
        }
    }

    public void SelectItem(Item newItem)
    {
        activeItem = newItem;

        if(activeItem.isItem)
        {
            useButtonText.text = "Use";
        }

        if(activeItem.isWeapon || activeItem.isArmour)
        {
            useButtonText.text = "Equip";
        }

        itemName.text = activeItem.itemName;
        itemDescription.text = activeItem.description;
    }

    public void DiscardItem()
    {
        if(activeItem != null)
        {
            GameManager.instance.RemoveItem(activeItem.itemName);
        }
    }
    
    public void OpenItemCharChoice()
    {
        itemCharChoiceMenu.SetActive(true);

        for(int i = 0; i < itemCharChoiceNames.Length; i++)
        {
            itemCharChoiceNames[i].text = GameManager.instance.playerStats[i].charName;
            itemCharChoiceNames[i].transform.parent.gameObject.SetActive(GameManager.instance.playerStats[i].gameObject.activeInHierarchy);
        }
    }

    public void CloseItemCharChoice()
    {
        itemCharChoiceMenu.SetActive(false);
    }

    public void UseItem(int selectChar)
    {
        activeItem.Use(selectChar);
        CloseItemCharChoice();
    }
}
