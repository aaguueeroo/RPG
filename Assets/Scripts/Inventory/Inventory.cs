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
    [SerializeField] private InventoryItem[] inventoryItems;

    private void Start()
    {
        inventoryItems = new InventoryItem[numberOfSlots];
    }

    public void AddToInventory(FloatingItem item, int num)
    {
        // for (int i = 0; i < numberOfSlots; i++)
        // {
        //     if (item.reference != null && item.reference == inventoryItems[i] &&
        //         inventoryItems[i].stack < inventoryItems[i].maxStack)
        //     {
        //         if (inventoryItems[i].stack + num > item.reference.maxStack)
        //         {
        //             num -= inventoryItems[i].stack - inventoryItems[i].maxStack;
        //             inventoryItems[i].stack = inventoryItems[i].maxStack;
        //             AddToInventory(item);
        //         }
        //         else
        //         {
        //             inventoryItems[i].stack += item.stack;
        //             item.stack = 0;
        //             return;
        //         }
        //     }
        // }
        //
        // for (int i = 0; i < numberOfSlots; i++)
        // {
        //     if (inventoryItems[i] == null && item.stack > item.reference.maxStack)
        //     {
        //         int stackRemain = item.stack - item.reference.maxStack;
        //         item.stack = item.reference.maxStack;
        //         inventoryItems[i] = item.reference;
        //         item.stack = stackRemain;
        //         AddToInventory(item);
        //     }
        //     else
        //     {
        //         inventoryItems[i] = item.reference;
        //         return;
        //     }
        // }
    }
}