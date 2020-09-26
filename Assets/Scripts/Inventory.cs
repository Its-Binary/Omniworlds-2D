using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[10];

    // Use this for initialization
    void Start () {
		
    }
	
    // Update is called once per frame
    void Update () {
		
    }

    public void AddItem(GameObject item) {
        bool itemAdded = false;

        //Lets see if there is an empty space
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory [i] == null) {
                inventory [i] = item;
                itemAdded = true;

                //Interact with the object
                item.SendMessage("DoInteraction");

                Debug.Log (item.name + " was added to inventory");
                break;
            }
        }

        //Inventory is full
        if (itemAdded == false) {
            Debug.Log ("Inventory was full, " + item.name + " was not added");
        }
    }

    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory [i] == item) {
                return true;
            }
        }

        return false;
    }
}