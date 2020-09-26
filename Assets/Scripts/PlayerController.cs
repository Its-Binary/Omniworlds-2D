using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float _currentMoveSpeed;
    public float diagonalMoveModifier;
    private Animator _anim;
    private bool _playerMoving;
    public Vector2 lastMove;
    private Rigidbody2D _rigidbody;
    private static bool _playerExists;
    public string startPoint;
    
    // Start is called before the first frame update
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (!_playerExists)
        {
            _playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    private void Update()
    {
        _playerMoving = false;
        
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            _rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, _rigidbody.velocity.y);
            _playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            _playerMoving = true;
            lastMove = new Vector2(0f,Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y);
        }
        
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f);
        }
        
        if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f) {
            _currentMoveSpeed = moveSpeed * diagonalMoveModifier;
        } else {
            _currentMoveSpeed = moveSpeed;
        }
        
        _anim.SetFloat("moveX", Input.GetAxisRaw("Horizontal"));
        _anim.SetFloat("moveY", Input.GetAxisRaw("Vertical"));
        _anim.SetBool("moving", _playerMoving);
        _anim.SetFloat("LastMoveX", lastMove.x);
        _anim.SetFloat("LastMoveY", lastMove.y);
    }
    
    
}
