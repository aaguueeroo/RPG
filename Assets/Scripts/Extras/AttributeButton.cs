using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType
{
    Strength,
    Wisdom,
    Agility,
}

public class AttributeButton : MonoBehaviour
{
    public static Action<AttributeType> EventAttributeAdded;
    [SerializeField] private AttributeType attributeType;
    
    public void AddAttribute()
    {
        EventAttributeAdded?.Invoke(attributeType);
    }
}

