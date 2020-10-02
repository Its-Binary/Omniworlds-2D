using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
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
    
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public void ToggleWindow(int windowNumber)
    {
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
    }
}
