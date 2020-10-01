using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName; 
    
    // Start is called before the first frame update
    void Start()
    {
        //Is the area the player is expecting to spawn the same as this? If so then set the player position
        if (transitionName == PlayerController.instance.areaTransitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }

        UIFade.instance.FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
