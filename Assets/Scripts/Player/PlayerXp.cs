using Managers;
using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    [Header("Stats")] 
    [SerializeField] private PlayerStats stats;
    
    [Header("Config")] 
    [SerializeField] private int levelMax;
    
    /// <summary>
    /// Base of xp to level up
    /// </summary>
    [SerializeField] private int xpBase;
    
    /// <summary>
    /// When the player level up, the xp needed to level up is multiplied by this value
    /// </summary>
    [SerializeField] private int valorIncremental;

    private float _currentXp;
    private float _currentXpTmp;
    private float _requiredXpToLevelUp;
    
    void Start()
    {
        stats.level = 1;
        _requiredXpToLevelUp = xpBase;
        stats.requiredXp = _requiredXpToLevelUp;
        UpdateXpBar();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddXp(10);
        }
    }

    public void AddXp(float xpAmount)
    {
        if (xpAmount > 0f)
        {
            float leftXpToNextLevel = _requiredXpToLevelUp - _currentXpTmp;
            if(xpAmount >= leftXpToNextLevel)
            {
                _currentXp += xpAmount;
                xpAmount -= leftXpToNextLevel;
                LevelUp();
                AddXp(xpAmount);
            }
            else
            {
                _currentXp += xpAmount;
                _currentXpTmp += xpAmount;
                if (_currentXpTmp == _requiredXpToLevelUp)
                {
                    LevelUp();
                }
            }
        }
        stats.currentXp = _currentXp;
        UpdateXpBar();
    }

    private void LevelUp()
    {
        if (stats.level < levelMax)
        {
            stats.level++;
            _currentXpTmp = 0f;
            _requiredXpToLevelUp *= valorIncremental;
            stats.requiredXp = _requiredXpToLevelUp;
            UpdateLevelText();
            stats.attributePoints += 3;
        }
    }

    public void RestorePlayer()
    {
        
    }

    private void UpdateXpBar()
    {
        UIManager.Instance.UpdatePlayerXp(_currentXpTmp, _requiredXpToLevelUp);
    }
    
    private void UpdateLevelText()
    {
        UIManager.Instance.UpdatePlayerLevel(stats.level);
    }
}
        
