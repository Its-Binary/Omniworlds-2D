using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    private bool _flashActive;
    public float flashLength;
    private float _flashCounter;

    private SpriteRenderer _sprite;

    private void Start()
    {
        currentHealth = maxHealth;
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            //Could throw us into a game over scene?
        }

        if (_flashActive)
        {
            //Update this to move to a seperate function for returning the colour
            if (_flashCounter > flashLength * .66f)
            {
                _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 0f);
            }
            else if (_flashCounter > flashLength * .33f)
            {
                _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 1f);
            }
            else if (_flashCounter > 0f)
            {
                _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 0f);
            }
            else
            {
                _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 1f);
                _flashActive = false;
            }

            _flashCounter -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;

        _flashActive = true;
        _flashCounter = flashLength;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
