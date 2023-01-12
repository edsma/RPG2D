using Assets.Scripts.Common;
using UnityEngine;

public class AddItems : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private InventoryItem referenceItem;
    [SerializeField] private int addQuantity;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(Constants.Tags.player))
        {
            Inventario.Instance.AddItem(referenceItem,addQuantity);
            Destroy(gameObject);
        }
    }

}
