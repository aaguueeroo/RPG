using UnityEngine;

[CreateAssetMenu (menuName = "Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Stats")]
    public float damage = 5f;
    public float defense = 2f;
    public float speed = 5f;
    public int level;
    public float currentXp;
    public float requiredXp;
    [Range(0f, 100f)] public float criticalPercentage;
    [Range(0f, 100f)] public float blockPercentage;

    [Header("Attributes")]
    public int strength;
    public int wisdom;
    public int agility;

    [HideInInspector] public int attributePoints;
    
    public void AddStrengthBonus()
    {
        damage += 2f;
        defense += 2f;
        blockPercentage += 0.04f;
    }
    
    public void AddWisdomBonus()
    {
        currentXp += 10;
        damage += 1f;
        criticalPercentage += 0.03f;
    }
    
    public void AddAgilityBonus()
    {
        speed += 1f;
        criticalPercentage += 0.005f;
    }

    public void ResetValues()
    {
        damage = 5f;
        defense = 2f;
        speed = 5f;
        level = 1;
        currentXp = 0f;
        requiredXp = 0f;
        criticalPercentage = 0f;
        blockPercentage = 0f;
        
        strength = 0;
        wisdom = 0;
        agility = 0;
        
        attributePoints = 0;
    }
}
