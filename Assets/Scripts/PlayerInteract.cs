using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionsObject currentInterObjScript = null;
    public Inventory inventory;

    void Update()
    {
        //Are we in range of an interactable object and has the interact button been pressed
        if (Input.GetButtonDown ("Interact") && currentInterObj) {
            //Check to see if the object is to be stored in the inventory
            if (currentInterObjScript.inventory) {
                inventory.AddItem (currentInterObj);
            }

            //Check to see if this object can be opened
            if (currentInterObjScript.openable) {

                //check to see if it is locked
                if (currentInterObjScript.locked) {

                    //check to see if we have the object needed to unlock, need to search the inventory for the item, if present then unlock else don't
                    if (inventory.FindItem (currentInterObjScript.itemNeeded)) {
                        //We have the item!!!!
                        currentInterObjScript.locked = false;

                        Debug.Log (currentInterObj.name + " was unlocked by using " + currentInterObjScript.itemNeeded);
                    } else {
                        Debug.Log (currentInterObj.name + " was not unlocked, you are missing " + currentInterObjScript.itemNeeded);
                    }
                } else {
                    //object is not locked - open the object
                    Debug.Log (currentInterObj.name + " is unlocked");
                }
            }
        }	
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("interObject")) {
            Debug.Log (other.name);

            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionsObject> ();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag ("interObject")) {
            if (other.gameObject == currentInterObj) {
                currentInterObj = null;
            }
        }
    }
}