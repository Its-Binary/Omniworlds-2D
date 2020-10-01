using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentXP;
    public int[] xpToNextLevel;
    public int maxLevel = 100;
    public int baseXp = 1000;
    public int currentHp;
    public int maxHp = 100;
    public int currentMp;
    public int maxMp = 30;
    public int[] mpLvlBonus;
    public int strength;
    public int defence;
    public int wpnPower;
    public int armourPwr;
    public string equippedWpn;
    public string equippedArmour;
    public Sprite charImage;
    
    // Start is called before the first frame update
    void Start()
    {
        xpToNextLevel = new int[maxLevel];
        xpToNextLevel[1] = baseXp;

        for (int i = 2; i < xpToNextLevel.Length; i++)
        {
            xpToNextLevel[i] = Mathf.FloorToInt(xpToNextLevel[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //fake button for testing xp gain
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddXp(1000);
        }
    }

    public void AddXp(int xpToAdd)
    {
        currentXP += xpToAdd;

        if (playerLevel < maxLevel)
        {
            if (currentXP > xpToNextLevel[playerLevel])
            {
                currentXP -= xpToNextLevel[playerLevel];

                playerLevel++;
                
                //determine whether to add to str or def based on odd or even
                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defence++;
                }

                maxHp = Mathf.FloorToInt(maxHp * 1.05f);
                currentHp = maxHp;

                maxMp += mpLvlBonus[playerLevel];
                currentMp = maxMp;
            }
        }

        if(playerLevel >= maxLevel)
        {
            currentXP = 0;
        }
    }
}
