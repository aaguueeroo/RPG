using UnityEngine;


    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private string layerIdle;
        [SerializeField] private string layerWalk;
    
    
        private Animator _animator;
        private PlayerMovement _characterMovement;
    
        /// <summary>
        ///  String to hash for direction x
        /// </summary>
        private readonly int _directionX = Animator.StringToHash("X");
    
        /// <summary>
        /// String to hash for direction y
        /// </summary>
        private readonly int _directionY = Animator.StringToHash("Y");
        private readonly int _isDead = Animator.StringToHash("IsDead");
    
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _characterMovement = GetComponent<PlayerMovement>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateLayers();
        
            if (_characterMovement.isMoving == false)
            {
                return;
            }
            _animator.SetFloat(_directionX, _characterMovement.DirectionMovement.x);
            _animator.SetFloat(_directionY, _characterMovement.DirectionMovement.y);

        }
    
        private void ActivateLayer(string layerName)
        {
            for (int i = 0; i < _animator.layerCount; i++)
            {
                _animator.SetLayerWeight(i, 0);
            }
            _animator.SetLayerWeight(_animator.GetLayerIndex(layerName), 1);
        }
    
        private void UpdateLayers()
        {
            ActivateLayer(_characterMovement.isMoving ? layerWalk : layerIdle);
        }

        public void RestorePlayer()
        {
            ActivateLayer(layerIdle);
            _animator.SetBool(_isDead, false);
        }
    
        private void OnPlayerDeath()
        {
            if (_animator.GetLayerWeight(_animator.GetLayerIndex(layerIdle)) == 1)
            {
                _animator.SetBool(_isDead, true);
            }
        }

        private void OnEnable()
        {
            PlayerHealth.EventPlayerDead += OnPlayerDeath;
        }

        private void OnDisable()
        {
            PlayerHealth.EventPlayerDead -= OnPlayerDeath;
        
        }
    }

