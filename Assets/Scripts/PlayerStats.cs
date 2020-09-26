using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int currentLevel;
    [SerializeField] int currentXp;
    [SerializeField] int[] toLevelUp;
    public int[] hpLevels;
    public int[] attackLevels;
    public int[] defenseLevels;
    public int currentHp;
    public int currentAttack;
    public int currentDefense;

    private PlayerHealthManager playerHealth;

    // Use this for initialization
    void Start () {
        currentHp      = hpLevels[1];
        currentAttack  = attackLevels[1];
        currentDefense = defenseLevels[1];

        playerHealth = FindObjectOfType<PlayerHealthManager>();
    }
	
    // Update is called once per frame
    void Update () {
        if(currentXp >= toLevelUp[currentLevel])
        {
            LevelUp();
        }
    }

    public void AddExperience(int xpToAdd)
    {
        currentXp += xpToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentHp      = hpLevels[currentLevel];
        currentAttack  = attackLevels[currentLevel];
        currentDefense = defenseLevels[currentLevel];

        playerHealth.maxHealth = currentHp;
        playerHealth.currentHealth += currentHp - hpLevels[currentLevel - 1];

    }
}