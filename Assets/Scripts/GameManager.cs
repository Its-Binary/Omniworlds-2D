using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CharStats[] playerStats;
    public bool gameMenuOpen;
    public bool dialogActive;
    public bool fadingBetweenAreas;
    //public bool shopActive;
    //public bool battleActive;
    //public string[] itemsHeld;
    //public int[] numberOfItems;
    //public Item[] referenceItems;
    //public int currentGold;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        DontDestroyOnLoad(gameObject);
        //SortItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
