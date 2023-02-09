using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.Common.Constants;

public class InventorySlot : MonoBehaviour
{
    public static Action<TypeOfInteraction, int> eventSlotInteraction; 

    [SerializeField] private Image itemIcon;
    [SerializeField] private GameObject backGroundQuantity;
    [SerializeField] private TextMeshProUGUI quantityTMP;
    public int Index { get; set; }
    
    public void UpdateSlotUI(InventoryItem item, int quantity)
    {
        itemIcon.sprite = item.Icon;
        quantityTMP.text = quantity.ToString();
    }

    public void ActivatedSlotUI(bool status)
    {
        itemIcon.gameObject.SetActive(status);
        backGroundQuantity.SetActive(status);
    }

    public void ClickSlot()
    {
        eventSlotInteraction?.Invoke(TypeOfInteraction.Click,Index);
        var indexSlotInitial = InventoryUI.Instance.IndexSlotInitialMove;
        if (indexSlotInitial != -1)
        {
            if (indexSlotInitial != Index)
            {
                Inventario.Instance.MoveItem(InventoryUI.Instance.IndexSlotInitialMove, Index);
            }
        }

    }

    public void SlotUseItem()
    {
        if (Inventario.Instance.ItemsInventory[Index] != null)
        {
            eventSlotInteraction?.Invoke(TypeOfInteraction.Use, Index);
        }
    }

    public void SlotDeleteItem()
    {
        if (Inventario.Instance.ItemsInventory[Index] != null)
        {
            eventSlotInteraction?.Invoke(TypeOfInteraction.remove, Index);
         
        }
    }

    public void SlotEquipItem()
    {
        if (Inventario.Instance.ItemsInventory[Index] != null)
        {
            eventSlotInteraction?.Invoke(TypeOfInteraction.Equip, Index);
        }
    }

    public void SlotRemoveItem()
    {
        if (Inventario.Instance.ItemsInventory[Index] != null)
        {
            eventSlotInteraction?.Invoke(TypeOfInteraction.remove, Index);
        }
    }
}
