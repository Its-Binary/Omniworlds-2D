using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    public float moveSpeed;
	private Vector2 _minWalkPoint;
	private Vector2 _maxWalkPoint;
	private Rigidbody2D _rb;
	public bool isMoving;
	public float walkTime;
	public float waitTime;
	private float _walkCounter;
	private float _waitCounter;
	private int _walkDirection;
	public Collider2D walkZone;
	private bool _hasWalkZone = false;

	// Use this for initialization
	void Start ()
	{
		_rb = GetComponent<Rigidbody2D>();
		_waitCounter = waitTime;
		_walkCounter = walkTime;

		ChooseDirection ();

		//Is a walking zone set?
		if (walkZone != null) {
			//set the minimum and maximum points that the villager is allowed to walk inside
			_minWalkPoint = walkZone.bounds.min;
			_maxWalkPoint = walkZone.bounds.max;

			_hasWalkZone = true;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isMoving) {
			_walkCounter -= Time.deltaTime;

			switch (_walkDirection) {

			//up
			case 0:
				_rb.velocity = new Vector2 (0, moveSpeed);

				//Is there a boundary and if so, are we going outside it
				if (_hasWalkZone && transform.position.y > _maxWalkPoint.y) {
					isMoving = false;
					_waitCounter = waitTime;
				}

				break;
			
			//right
			case 1:
				_rb.velocity = new Vector2 (moveSpeed, 0);

				if (_hasWalkZone && transform.position.x > _maxWalkPoint.x) {
					isMoving = false;
					_waitCounter = waitTime;
				}

				break;
			
			//down
			case 2:
				_rb.velocity = new Vector2 (0, -moveSpeed);

				if (_hasWalkZone && transform.position.y < _minWalkPoint.y) {
					isMoving = false;
					_waitCounter = waitTime;
				}

				break;
			
			//left
			case 3:
				_rb.velocity = new Vector2 (-moveSpeed, 0);

				if (_hasWalkZone && transform.position.x < _minWalkPoint.x) {
					isMoving = false;
					_waitCounter = waitTime;
				}

				break;
			}

			if (_walkCounter < 0) {
				isMoving = false;
				_walkCounter = waitTime;
			}
		} else {
			_waitCounter -= Time.deltaTime;

			if (_waitCounter < 0) {
				ChooseDirection ();
			}
		}
	}

	public void ChooseDirection()
	{
		_walkDirection = Random.Range (0, 4);
		isMoving = true;
		_walkCounter = walkTime;

	}
}