    using Managers;
    using UnityEngine;

    public class PlayerMana : MonoBehaviour
    {
        [SerializeField] private float initialMana;
        [SerializeField] private float maxMana;
        [SerializeField] private float manaRegenerationRate;
        
        public float CurrentMana { get; private set; }
        
        private PlayerHealth _playerHealth;

        private void Awake()
        {
            _playerHealth = GetComponent<PlayerHealth>();
        }

        private void Start()
        {
            CurrentMana = initialMana;
            UpdateManaBar();
            
            InvokeRepeating(nameof(RegenerateMana),1,1);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                UseMana(10);
            }
        }

        public void UseMana(float amount)
        {
            if (CurrentMana >= amount)
            {
                CurrentMana -= amount;
                UpdateManaBar();
            }
            else
            {
                CurrentMana = 0;
            }
        }

        private void RegenerateMana()
        {
            if(_playerHealth.Health > 0f && CurrentMana < maxMana)
            {
                CurrentMana += manaRegenerationRate;
                UpdateManaBar();
            }
        }

        public void RestorePlayer()
        {
            CurrentMana = initialMana;
            UpdateManaBar();
        }

        private void UpdateManaBar()
        {
            UIManager.Instance.UpdatePlayerMana(CurrentMana, maxMana);
        }
        
    }