using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootButton : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    
    public DropItem ItemPickeUp { get; private set; }

    public void ConfigureLootItem(DropItem dropItem)
    {
        ItemPickeUp = dropItem;
        itemIcon.sprite = ItemPickeUp.Item.Icon;
        itemName.text= $"{ItemPickeUp.Item.Name} x {ItemPickeUp.Amount}";
    }
}
