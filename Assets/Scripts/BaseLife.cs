using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseLife : MonoBehaviour
{
    [SerializeField] protected float initialHealth;
    [SerializeField] protected float maxHealth;

    public float Health { get; protected set; }
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Health = initialHealth;
        
    }
    
    public void decreaseHealth(float amount)
    {
        if (amount <= 0)
        {
            return;
        }
        if (amount > 0)
        {
            Health -= (int) amount;
            UpdateHealthBar(Health, maxHealth);
            if (Health <= 0)
            {
                Health = 0;
                UpdateHealthBar(Health,maxHealth);
                PlayerDead();
            }
        }
    }

    protected virtual void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        
        
    }
    
    protected virtual void PlayerDead()
    {
        
    }

}
