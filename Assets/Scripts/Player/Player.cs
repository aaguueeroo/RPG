using UnityEngine;



    public class Player : MonoBehaviour
    {

        [SerializeField] private PlayerStats stats;
        public PlayerHealth PlayerHealth { get; private set; }
        public PlayerMana PlayerMana { get; private set; }
        public PlayerAnimations PlayerAnimations { get; private set; }
        public PlayerXp PlayerXp { get; private set; }
        
        private void Awake()
        {
            PlayerHealth = GetComponent<PlayerHealth>();
            PlayerAnimations = GetComponent<PlayerAnimations>();
            PlayerMana = GetComponent<PlayerMana>();
            PlayerXp = GetComponent<PlayerXp>();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void RestorePlayer()
        {
            PlayerHealth.RestorePlayer();
            PlayerAnimations.RestorePlayer();
            PlayerMana.RestorePlayer();
            PlayerXp.RestorePlayer();
        }

        private void OnAttributeAdded(AttributeType type)
        {
            if(stats.attributePoints <= 0) return;
            
            switch (type)
            {
                case AttributeType.Agility:
                    stats.agility++;
                    stats.AddAgilityBonus();
                    break;
                case AttributeType.Strength:
                    stats.strength++;
                    stats.AddStrengthBonus();
                    break;
                case AttributeType.Wisdom:
                    stats.wisdom++;
                    stats.AddWisdomBonus();
                    break;
            }
            stats.attributePoints--;
            
        }

        private void OnEnable()
        {
            AttributeButton.EventAttributeAdded += OnAttributeAdded;
        }

        private void OnDisable()
        {
            AttributeButton.EventAttributeAdded -= OnAttributeAdded;   
        }
        
        
    }
