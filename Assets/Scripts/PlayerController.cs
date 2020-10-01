using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Rigidbody2D rigidBody;
    public float moveSpeed;
    public Animator anim;
    public string areaTransitionName;
    private Vector3 _bottomLeftLimit;
    private Vector3 _topRightLimit;
    public bool canMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }

        anim.SetFloat("moveX", rigidBody.velocity.x);
        anim.SetFloat("moveY", rigidBody.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Vertical") == 1 ||
            Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == -1)
        {
            if (canMove)
            {
                anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _bottomLeftLimit.x, _topRightLimit.x), 
                                         Mathf.Clamp(transform.position.y, _bottomLeftLimit.y, _topRightLimit.y), transform.position.z);
        
    }
    
    //This is to stop the player going out of bounds
    public void SetBounds(Vector3 bottomLeft, Vector3 topRight)
    {
        _bottomLeftLimit = bottomLeft + new Vector3(.5f, 1f, 0f);
        _topRightLimit = topRight + new Vector3(-.5f, -1f, 0f);
    }
}
