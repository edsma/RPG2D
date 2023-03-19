using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTienda : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private Image itemIcon;
    [SerializeField]
    private TextMeshProUGUI itemName;
    [SerializeField]
    private TextMeshProUGUI itemCost;
    [SerializeField]
    private TextMeshProUGUI amountToBuy;

    public ItemVenta ItemUpchange { get; private set; }
    private int amount;
    private int initialPrice;
    private int actualPrice;

    private void Update()
    {
        amountToBuy.text = amount.ToString();
        itemCost.text = actualPrice.ToString();
    }


    public void ConfigureItemToSell(ItemVenta item)
    {
        ItemUpchange = item;
        itemIcon.sprite = ItemUpchange.Item.Icon;
        itemName.text= ItemUpchange.Item.Name;
        itemCost.text = ItemUpchange.Cost.ToString();
        amount = 1;
        initialPrice = ItemUpchange.Cost ;
        actualPrice = ItemUpchange.Cost;
    }

    public void BuyItem()
    {
        if (CoinsManager.Instance.totalsCoins >= actualPrice)
        {
            Inventario.Instance.AddItem(ItemUpchange.Item, amount);
            CoinsManager.Instance.RemoveCoins(actualPrice);
            amount = 1;
            actualPrice = initialPrice;
        }
    }

    public void SumItemToBuy()
    {
        int priceBuy = initialPrice * (amount + 1);
        if (CoinsManager.Instance.totalsCoins >= priceBuy)
        {
            amount++;
            actualPrice = initialPrice * amount;
        }
    }

    public void ResItemToBuy()
    {
        if (amount.Equals(1))
        {
            return;
        }

        amount--;
        actualPrice = initialPrice * amount;
    }

}
