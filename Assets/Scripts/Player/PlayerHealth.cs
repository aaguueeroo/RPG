using System;
using Managers;
using UnityEngine;


    public class PlayerHealth : BaseLife
    {
        public static Action EventPlayerDead;
        public bool IsDead { get; private set; }
        public bool IsCurable => Health < maxHealth;

        private BoxCollider2D _boxCollider2D;

        public void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        protected override void Start()
        {
            base.Start();
            UpdateHealthBar(Health, maxHealth);
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                decreaseHealth(10);
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {  
                IncreaseHealth(10);
            }
        }

        protected override void PlayerDead()
        {
            _boxCollider2D.enabled = false;
            IsDead = true;
            EventPlayerDead?.Invoke();
        }

        public void IncreaseHealth(float amount)
        {

            if (IsDead)
            {
                return;
            }

            if (IsCurable)
            {
                Health += amount;
                if (Health > maxHealth)
                {
                    Health = maxHealth;
                }
                UpdateHealthBar(Health, maxHealth);
            }
        }

        public void RestorePlayer()
        {
            _boxCollider2D.enabled = true;
            IsDead = false;
            Health = initialHealth;
            UpdateHealthBar(Health,initialHealth);
            
        }

        protected override void UpdateHealthBar(float currentHealth, float maxHealth)
        {
            UIManager.Instance.UpdatePlayerLife(currentHealth, maxHealth);
        }
    }
