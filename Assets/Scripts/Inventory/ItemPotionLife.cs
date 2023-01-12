using UnityEngine;

namespace Assets.Scripts.Inventory
{
    [CreateAssetMenu(menuName = "Items/Potion Health")]
    public class ItemPotionLife: InventoryItem
    {
        [Header("Potion info")]
        public float HpRestauration;

        public override bool UseItem()
        {

            if (Inventario.Instance.character._characterHealth.cantBeCured)
            {
                Inventario.Instance.character._characterHealth.RestaurateHealth(HpRestauration);
                return true;
            }
            return false;
        }


    }
}
