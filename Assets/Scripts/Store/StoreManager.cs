using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private ItemTienda itemStorePrefab;
    [SerializeField] private Transform panelContainer;

    [Header("Items")]
    [SerializeField] private ItemVenta[] availableItems;


    private void Start()
    {
        UploadItemForSell();
    }

    private void UploadItemForSell()
    {
        for (int i = 0; i < availableItems.Length; i++)
        {
            ItemTienda storeItem = Instantiate(itemStorePrefab, panelContainer);
            storeItem.ConfigureItemToSell(availableItems[i]);
        }
    }
}
