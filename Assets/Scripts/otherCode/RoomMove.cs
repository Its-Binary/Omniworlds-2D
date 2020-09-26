using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement _camera;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _camera.minPosition += cameraChange;
            _camera.maxPosition += cameraChange;
            other.transform.position += playerChange;

            if (needText)
            {
                StartCoroutine(PlaceNameCo());
            }
        }
    }

    private IEnumerator PlaceNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
