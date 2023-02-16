using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{

    [SerializeField] private int numberOfSlots;
    public int NumberOfSlots => numberOfSlots;
    
    [Header("Items")]
    [SerializeField] private InventoryItem[] items;

    private void Start()
    {
        items = new InventoryItem[numberOfSlots];
    }
}
