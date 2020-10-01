using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string areaToLoad;
    public string areaTransitionName;
    public AreaEntrance entrance;
    public float waitToLoad = 1f;
    private bool _shouldLoadAfterFade;
        
    // Start is called before the first frame update
    void Start()
    {
        entrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        if (_shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;

            if (waitToLoad <= 0)
            {
                _shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _shouldLoadAfterFade = true;

            UIFade.instance.FadeToBlack();

            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}
