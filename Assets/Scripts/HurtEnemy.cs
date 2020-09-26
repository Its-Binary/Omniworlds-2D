using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;
    private int _currentDamage;
    private PlayerStats _stats;

    // Use this for initialization
    private void Start () {
        _stats = FindObjectOfType<PlayerStats>();
    }
	
    // Update is called once per frame
    void Update () {
		
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            _currentDamage = damageToGive + _stats.currentAttack;

            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(_currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            GameObject clone = Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = _currentDamage;
        }
    }
}