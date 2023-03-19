
using System;
using UnityEngine;

[Serializable]
public class recipe 
{
    public string Name;
    [Header("1er Material")]
    public InventoryItem Item1;
    public int Item1AmountRequired;
    [Header("2er Material")]
    public InventoryItem Item2;
    public int Item2AmountRequired;

    [Header("Result")]
    public InventoryItem itemResult;
    public int ItemResultAmount;


}
