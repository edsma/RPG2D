using Assets.Scripts.Characters;
using Assets.Scripts.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using static Assets.Scripts.Common.Constants;

public class Inventario : Singleton<Inventario>
{
    [SerializeField] public Character character;

    [SerializeField] private int numberOfSlots;
    public int NumberOfSlots => numberOfSlots;

    [Header("Items")]
    [SerializeField] private InventoryItem[] itemsInventory;
    public InventoryItem[] ItemsInventory => itemsInventory; 

    // Start is called before the first frame update
    void Start()
    {
        itemsInventory = new InventoryItem[numberOfSlots];
    }

    public void AddItem(InventoryItem item, int quantity)
    {
        if (item == null)
        {
            return;
        }

        List<int> indexs = ValidateExistCapacity(item.Id);
        if (item.canHaveMany && indexs.Any())
        {
            for (int i = 0; i < indexs.Count; i++)
            {
                if (itemsInventory[indexs[i]].quantity < item.maxQuantity)
                {
                    itemsInventory[indexs[i]].quantity += quantity;
                    if (itemsInventory[indexs[i]].quantity > item.maxQuantity)
                    {
                        int difference = itemsInventory[indexs[i]].quantity - item.maxQuantity;
                        itemsInventory[indexs[i]].quantity = difference;
                        AddItem(item,difference);
                    }
                    InventoryUI.Instance.DrawITemInventory(item, itemsInventory[indexs[i]].quantity, indexs[i]);
                }
            }
        }
        if (quantity <= 0)
        {
            return;
        }

        if (quantity> item.maxQuantity)
        {
            AddItemDisponibilitySlot(item,item.maxQuantity);
            quantity -= item.maxQuantity;
            AddItem(item, quantity);
        }
        else
        {
            AddItemDisponibilitySlot(item, quantity);

        }
    }

    private void AddItemDisponibilitySlot(InventoryItem item,int quantity)
    {
        for (int i = 0; i < itemsInventory.Length; i++)
        {
            if (itemsInventory[i] == null)
            {
                itemsInventory[i] = item.CopiarItem();
                itemsInventory[i].quantity = quantity;
                InventoryUI.Instance.DrawITemInventory(item, quantity, i);
                return;
            }
        }
    }

    private List<int> ValidateExistCapacity(string itemId)
    {
        List<int> indexItem = new List<int>();
        for(int i = 0; i< itemsInventory.Length;i++)
        {
            if (itemsInventory[i] != null && itemsInventory[i].Id == itemId)
            {
                indexItem.Add(i);
                break;
            }

        
        }
        return indexItem;
    }

    private void OnEnable()
    {
        InventorySlot.eventSlotInteraction += SlotInteractionResponse;
    }

    private void DeleteItem(int index)
    {
        itemsInventory[index].quantity--;
        if (itemsInventory[index].quantity <=0 )
        {
            itemsInventory[index].quantity = 0;
            itemsInventory[index] = null;
            InventoryUI.Instance.DrawITemInventory(null, 0, index);
        }
        else
        {
            InventoryUI.Instance.DrawITemInventory(itemsInventory[index], itemsInventory[index].quantity,index);
        }
    }

    public void MoveItem(int indexInicial, int finalIndex)
    {
        if (itemsInventory[indexInicial] == null || ItemsInventory[finalIndex] != null)
        {
            return;
        }

        InventoryItem itemMove = itemsInventory[indexInicial].CopiarItem();
        itemsInventory[finalIndex] = itemMove;
        InventoryUI.Instance.DrawITemInventory(itemMove,itemMove.quantity,finalIndex);

        itemsInventory[indexInicial] = null;
        InventoryUI.Instance.DrawITemInventory(null,0,indexInicial);
    }

    private void UseItem(int index)
    {
        if (itemsInventory[index] == null)
        {
            return;
        }

        if (itemsInventory[index].UseItem())
        {
            DeleteItem(index);
        }
    }

    private void SlotInteractionResponse(Constants.TypeOfInteraction type, int index)
    {
        switch (type)
        {
            case TypeOfInteraction.Use:
                UseItem(index);
                break;
            case TypeOfInteraction.Equip:

                break;
            case TypeOfInteraction.remove:
                DeleteItem(index);
                break;
        }
    }

    private void OnDisable()
    {
        InventorySlot.eventSlotInteraction -= SlotInteractionResponse;
    }


}
