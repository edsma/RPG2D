using UnityEngine;
namespace Assets.Scripts.Inventory
{
    [CreateAssetMenu(menuName = "Items/Potion mana")]
    public class ItemPotionMana: InventoryItem
    {
        [Header("Potion info")]
        public float ManaRestauration;

        public override bool UseItem()
        {

            if (Inventario.Instance.character._characterHealth.cantBeCured)
            {
                Inventario.Instance.character._characterMana.RestartMana();
                return true;
            }
            return false;
        }
    }
}
