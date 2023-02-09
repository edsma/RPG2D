
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Assets.Scripts.Common.Constants;

public class InventoryUI : Singleton<InventoryUI>
{
    [Header("Panel inventory description")]
    [SerializeField] private GameObject panelInventoryDescription;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI descriptionItem;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] InventorySlot slotPrefab;
    [SerializeField] Transform container;
    public int IndexSlotInitialMove { get; private set; }
    public InventorySlot SlotSelected { get; private set; }
    List<InventorySlot> slotsDisponible = new List<InventorySlot>();


    private void Start()
    {
        StartInventary();
        IndexSlotInitialMove = -1;
    }

    private void Update()
    {
        UpdateSlotSelected();
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (SlotSelected != null)
            {
                IndexSlotInitialMove = SlotSelected.Index;
            }
        }
    }

    public void EquipItem()
    {
        if (SlotSelected != null)
        {
            SlotSelected.SlotEquipItem();
        }
    }

    public void RemoveItem()
    {
        if (SlotSelected != null)
        {
            SlotSelected.SlotRemoveItem();
        }
    }

    void StartInventary()
    {
        for (int i = 0; i < Inventario.Instance.NumberOfSlots; i++)
        {
            InventorySlot newSlot =  Instantiate(slotPrefab,container);
            newSlot.Index = i;
            slotsDisponible.Add(newSlot);
        }
    }

    private void UpdateSlotSelected()
    {
        GameObject goSelected = EventSystem.current.currentSelectedGameObject;
        if (goSelected == null)
        {
            return;
        }

        InventorySlot slot = goSelected.GetComponent<InventorySlot>();
        if (slot != null)
        {
            SlotSelected = slot;
        }
    }

    public void DrawITemInventory(InventoryItem itemForAdd, int quantity, int indexItem)
    {
        InventorySlot slot = slotsDisponible[indexItem];
        if (itemForAdd != null)
        {
            slot.ActivatedSlotUI(true);
            slot.UpdateSlotUI(itemForAdd, quantity);
        }
        else
        {
            slot.ActivatedSlotUI(false);

        }
    }

    #region MyRegion
    private void OnEnable()
    {
        InventorySlot.eventSlotInteraction += SlotInteractionResponse;
    }

    private void OnDisable()
    {
        InventorySlot.eventSlotInteraction -= SlotInteractionResponse;
    }

    private void UpdateInventoryDescription(int index)
    {
        if (Inventario.Instance.ItemsInventory[index] != null)
        {
            var item = Inventario.Instance.ItemsInventory[index];
            itemIcon.sprite = item.Icon;
            itemName.text = item.Name;
            descriptionItem.text = item.Description;
            panelInventoryDescription.SetActive(true);
        }
        else
        {
            panelInventoryDescription.SetActive(false);
        }
    }

    private void SlotInteractionResponse(TypeOfInteraction type, int index)
    {
        if (type.Equals(TypeOfInteraction.Click))
        {
            UpdateInventoryDescription(index);
        }


    }

    public void UseItem()
    {
        if (SlotSelected != null)
        {
            SlotSelected.SlotUseItem();
        }
    }

    public void DeleteItem()
    {
        if (SlotSelected != null)
        {
            SlotSelected.SlotDeleteItem();
        }
    }
    #endregion

}
