using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text hpText;
    public PlayerHealthManager playerHealth;
    private static bool _uiExists;

    // Use this for initialization
    void Start () {
        if (!_uiExists)
        {
            _uiExists = true;

            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
    // Update is called once per frame
    void Update () {
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.currentHealth;
        hpText.text = "HP: " + playerHealth.currentHealth + "/" + playerHealth.maxHealth;
    }
}