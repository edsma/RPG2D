using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Common.Constants;

public class InventoryItem : ScriptableObject
{
    [Header("Parametros")]
    public string Id;
    public string Name;
    public Sprite Icon;
    [TextArea] public string Description;

    [Header("Information")]
    public TypesOfItem Type;
    public bool isForUse;
    public bool canHaveMany;
    public int maxQuantity;

    [HideInInspector] public int quantity;

    public InventoryItem CopiarItem()
    {
        InventoryItem newInstance = Instantiate(this);
        return newInstance;
    }

    public virtual bool UseItem()
    {
        return true;
    }

    public virtual bool EquipItem()
    {
        return true;
    }

    public virtual bool RemoveItem()
    {
        return true;
    }

}
