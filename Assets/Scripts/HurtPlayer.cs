using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    private int _currentDamage;
    public GameObject damageNumber;
    private PlayerStats _stats;

    // Use this for initialization
    void Start () {
        _stats = FindObjectOfType<PlayerStats>();
    }
	
    // Update is called once per frame
    void Update () {
		
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _currentDamage = damageToGive - _stats.currentDefense;

            if(_currentDamage <= 0)
            {
                _currentDamage = 1;
            }

            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(_currentDamage);
            GameObject clone = Instantiate(damageNumber, collision.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = _currentDamage;
        }
    }
}