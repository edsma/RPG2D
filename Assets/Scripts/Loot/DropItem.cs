using System;
using UnityEngine;

[Serializable]
public class DropItem 
{
    [Header("Info")]
    public string Name;

    public InventoryItem Item;

    public int Amount;

    [Header("Drop")]
    [Range(0,100)]public float PercentajeDrop;

    public bool ItemPickeUp { get; set; }

}
