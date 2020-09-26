using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArea : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string exitPoint;
    private PlayerController _player;
    
    // Start is called before the first frame update
    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);

            _player.startPoint = exitPoint;
        }
    }
}
