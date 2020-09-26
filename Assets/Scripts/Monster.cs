using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private int _damageToPlayer;
    private int _health;
    private int _maxHealth;
    private int _experienceGained;

    public GameObject damageNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int DamagePlayer
    {
        get => _damageToPlayer;
        set => _damageToPlayer = value;
    }

    public int CurrentHealth
    {
        get => _health;
        set => _health = value;
    }

    public int MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value;
    }

    public int ExperienceGained
    {
        get => _experienceGained;
        set => _experienceGained = value;
    }
    
    public int TakeDamage(int damage)
    {
        //Could look at this for damage resistance int num = Math.Max(1, damage - this.resilience);
        this._health -= damage;

        if (this._health <= 0)
        {
            //Monster is dead!
            //need to kill it off
        }

        return damage; //this is for popup damage numbers
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(DamagePlayer);
            GameObject clone = Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));

            clone.GetComponent<FloatingNumbers>().damageNumber = DamagePlayer;
        }
    }
}
