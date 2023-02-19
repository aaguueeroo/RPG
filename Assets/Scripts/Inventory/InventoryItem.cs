using UnityEngine;

public enum ItemTypes
{
    Weapon,
    Potion,
    Ingredient, 
    Paper,
    Treasure,
}

public class InventoryItem : ScriptableObject
{
    
    
    [Header("Parameters")] 
    public BoxCollider2D itemCollider;
    public string id;
    public Sprite icon;
    public string name;
    [TextArea] public string description;

    [Header("Information")] 
    public ItemTypes type;
    public bool isConsumable;
    public bool isStackable;
    public int maxStack;

    [HideInInspector] public int stack;
}