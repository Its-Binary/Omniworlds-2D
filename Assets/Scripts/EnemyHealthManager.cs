using UnityEngine;
using UnityEngine.Serialization;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    private PlayerStats _playerStats;
    public int expToGive;

    // Use this for initialization
    private void Start () {
        currentHealth = maxHealth;	
        _playerStats = FindObjectOfType<PlayerStats> ();
    }

    // Update is called once per frame
    private void Update () {
        if(currentHealth <= 0)
        {
            Destroy (gameObject);

            _playerStats.AddExperience (expToGive);
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}