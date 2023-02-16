using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    
    [SerializeField] private InventorySlot slotPrefab; 
    [SerializeField] private Transform container;

    private List<InventorySlot> slots = new List<InventorySlot>();

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < Inventory.Instance.NumberOfSlots; i++)
        {
            InventorySlot newSlot = Instantiate(slotPrefab, container);
            newSlot.Index = i;
            slots.Add(newSlot);
        }
    }
}
