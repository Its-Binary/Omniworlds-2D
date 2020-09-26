using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Rigidbody2D _rb;
    private bool _moving;
    [SerializeField] float timeBetweenMove;
    private float _timeBetweenMoveCounter;
    [SerializeField] float timeToMove;
    private float _moveCounter;
    private Vector3 _direction;
    [SerializeField] float reloadPause;
    private bool _reloading;
    private GameObject _thePlayer;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody2D>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //moveCounter = timeToMove;
        _timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        _moveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
		if(_moving)
        {
            _moveCounter -= Time.deltaTime;
            _rb.velocity = _direction;

            if(_moveCounter < 0f)
            {
                _moving = false;
                //timeBetweenMoveCounter = timeBetweenMove;
                _timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            _timeBetweenMoveCounter -= Time.deltaTime;
            _rb.velocity = Vector2.zero;

            if(_timeBetweenMoveCounter < 0f)
            {
                _moving = true;
                //moveCounter = timeToMove;
                _moveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

                _direction = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }

        if(_reloading)
        {
            reloadPause -= Time.deltaTime;

            if(reloadPause < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                _thePlayer.SetActive(true);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.SetActive(false);
            _reloading = true;
            _thePlayer = collision.gameObject;
        }
    }
}