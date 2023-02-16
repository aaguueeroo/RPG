using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [Header("Panels")] 
        [SerializeField] private GameObject statsPanel;
        [SerializeField] private GameObject inventoryPanel;
        
        
        [Header("Bars")]
        [SerializeField] private Image playerHealth;
        [SerializeField] private Image playerMana;
        [SerializeField] private Image playerXp;
        
        [Header("Bar Fields")]
        [SerializeField] private TextMeshProUGUI healthTMP;
        [SerializeField] private TextMeshProUGUI manaTMP;
        [SerializeField] private TextMeshProUGUI xpTMP;
        [SerializeField] private TextMeshProUGUI levelTMP;
        
        [Header("Stats")] 
        [SerializeField] private PlayerStats stats;
        
        [Header("Stat Fields")]
        [SerializeField] private TextMeshProUGUI statDamageTMP;
        [SerializeField] private TextMeshProUGUI statDefenseTMP;
        [SerializeField] private TextMeshProUGUI statCriticalTMP;
        [SerializeField] private TextMeshProUGUI statBlockTMP;
        [SerializeField] private TextMeshProUGUI statSpeedTMP;
        [SerializeField] private TextMeshProUGUI statLevelTMP;
        [SerializeField] private TextMeshProUGUI statXpTMP;
        [SerializeField] private TextMeshProUGUI statRequiredXpTMP;
        [SerializeField] private TextMeshProUGUI attributeStrengthTMP;
        [SerializeField] private TextMeshProUGUI attributeWisdomTMP;
        [SerializeField] private TextMeshProUGUI attributeAgilityTMP;
        [SerializeField] private TextMeshProUGUI attributePointsTMP;

        private float _currentLife;
        private float _maxLife;
        private float _currentMana;
        private float _maxMana;
        private float _currentXp;
        private float _maxXp;
        private int _currentLevel;

        // Update is called once per frame
        void Update()
        {
            UpdatePlayerUI();
            UpdateStatsPanel();
        }

        private void UpdatePlayerUI()
        {
            playerHealth.fillAmount = Mathf.Lerp(playerHealth.fillAmount, _currentLife / _maxLife, Time.deltaTime * 10f);
            playerMana.fillAmount = Mathf.Lerp(playerMana.fillAmount, _currentMana / _maxMana, Time.deltaTime * 10f);
            playerXp.fillAmount = Mathf.Lerp(playerXp.fillAmount, _currentXp / _maxXp, Time.deltaTime * 10f);
            
            healthTMP.text = _currentLife.ToString();
            manaTMP.text = _currentMana.ToString();
            xpTMP.text = $"{((_currentXp/_maxXp)*100):F2}%";
            levelTMP.text = "level " + stats.level;
        }

        private void UpdateStatsPanel()
        {
            if (statsPanel.activeSelf == false) return;
            
            statDamageTMP.text = stats.damage.ToString();
            statDefenseTMP.text = stats.defense.ToString();
            statCriticalTMP.text = $"{stats.criticalPercentage}%";
            statBlockTMP.text = $"{stats.blockPercentage}%";
            statSpeedTMP.text = stats.speed.ToString();
            statLevelTMP.text = stats.level.ToString();
            statXpTMP.text = stats.currentXp.ToString();
            statRequiredXpTMP.text = stats.requiredXp.ToString();
            
            attributeStrengthTMP.text = stats.strength.ToString();
            attributeWisdomTMP.text = stats.wisdom.ToString();
            attributeAgilityTMP.text = stats.agility.ToString();
            attributePointsTMP.text = "Points: " + stats.attributePoints;
        }
    
        public void UpdatePlayerLife(float currentLife, float maxLife)
        {
            this._currentLife = currentLife;
            this._maxLife = maxLife;
        }
        
        public void UpdatePlayerMana(float currentMana, float maxMana)
        {
            this._currentMana = currentMana;
            this._maxMana = maxMana;
        }
        
        public void UpdatePlayerXp(float currentXp, float maxXp)
        {
            this._currentXp = currentXp;
            this._maxXp = maxXp;
        }

        public void UpdatePlayerLevel(int level)
        {
            this._currentLevel = level;
        }
        
        #region Panels

        public void toggleStatsPanel()
        {
            if (inventoryPanel.activeSelf) inventoryPanel.SetActive(false);
            statsPanel.SetActive(!statsPanel.activeSelf);
        }

        public void toggleInventoryPanel()
        {
            if(statsPanel.activeSelf) statsPanel.SetActive(false);
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
        
        #endregion
    }
}
