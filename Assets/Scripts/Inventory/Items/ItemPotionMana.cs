using UnityEngine;

[CreateAssetMenu(menuName = "Items/PotionMana")]

public class ItemPotionMana : InventoryItem
{
    [Header("Potion info")] 
    public float restorationAmount;
}