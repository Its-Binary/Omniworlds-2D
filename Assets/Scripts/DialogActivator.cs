using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public string[] lines;
    private bool _canActivate;
    public bool isPerson = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_canActivate && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogBox.activeInHierarchy)
        {
            DialogManager.instance.ShowDialog(lines, isPerson);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canActivate = false;
        }
    }
}
