using UnityEngine;

public class InteractionsObject : MonoBehaviour
{
    public bool inventory; 	      //Bool to determin if the object can be stored in an inventory
    public bool openable; 	      //If true, this object can be opened
    public bool locked; 	      //If true, the object is locked and needs an item or something to unlock
    public GameObject itemNeeded; //Item needed to react to interaction

    public Animator anim;

    // Use this for initialization
    void Start () {
		
    }
	
    // Update is called once per frame
    void Update () {
		
    }

    public void DoInteraction()
    {
        //Picked up and put in inventory
        gameObject.SetActive(false);
    }

    public void Open()
    {
        anim.SetBool ("open", true);
    }
}