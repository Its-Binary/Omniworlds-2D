using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    private PlayerController _player;
    private CameraController _camera;
    public Vector2 startDirection;
    [SerializeField] string pointName;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();

        if (_player.startPoint == pointName)
        {
            _player.transform.position = transform.position;
            _player.lastMove = startDirection;

            _camera = FindObjectOfType<CameraController>();
            _camera.transform.position = new Vector3(transform.position.x, transform.position.y, _camera.transform.position.z);
        }
    }

}
