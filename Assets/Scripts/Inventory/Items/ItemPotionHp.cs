using UnityEngine;

[CreateAssetMenu(menuName = "Items/PotionHp")]

public class ItemPotionHp : InventoryItem
{
    [Header("Potion info")] 
    public float restorationAmount;
}
