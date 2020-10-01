using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    //Generally the player but whatever we want the camera to track
    public Transform target;
    
    //This is to setup for our bounds (use ground layer
    public Tilemap map;
    private Vector3 _bottomLeftLimit;
    private Vector3 _topRightLimit;
    
    //Camera measurements are taken from the center so we need half the width and height to make sure we do not show
    //anything that is out of bounds.
    private float _halfHeight;
    private float _halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        //Lets find the player
        target = FindObjectOfType<PlayerController>().transform;
        
        //work out the half height and width using the camera aspect ratio and size
        _halfHeight = Camera.main.orthographicSize;
        _halfWidth = _halfHeight * Camera.main.aspect;
        
        map.CompressBounds();

        //use the tilemap bounds + the half width and height for limits
        _bottomLeftLimit = map.localBounds.min + new Vector3(_halfWidth, _halfHeight, 0f);
        _topRightLimit = map.localBounds.max + new Vector3(-_halfHeight, -_halfWidth, 0f);
        
        //pass the info through to the player controller to set its limits
        PlayerController.instance.SetBounds(map.localBounds.min, map.localBounds.max);
    }

    //Using LateUpdate() to reduce any chance of lag with the camera as it is the last thing to be updated
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        
        //keep the camera inside the bounds set
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _bottomLeftLimit.x, _topRightLimit.x),
                                             Mathf.Clamp(transform.position.y, _bottomLeftLimit.y, _topRightLimit.y), transform.position.z);
        
        
    }
}
