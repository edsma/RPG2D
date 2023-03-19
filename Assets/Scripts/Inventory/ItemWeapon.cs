using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon")]
public class ItemWeapon : InventoryItem
{
    [Header("Weapon")] public Weapon weapon;

    public override bool EquipItem()
    {
        if (ContainerWeapon.Instance.equipedWeapon != null)
        {
            return false;
        }

        ContainerWeapon.Instance.EquipArm(this);
        return true;
    }

    public override bool RemoveItem()
    {
        if (ContainerWeapon.Instance.equipedWeapon == null)
        {
            return false;
        }

        ContainerWeapon.Instance.RemoveWeapon();
        return true;
    }

    public override string DescriptionItemCrafting()
    {
        return $"- Chance critico: {weapon.criticDamage} {Environment.NewLine}" +
            $"- Chance bloqueo: {weapon.blockPosibility}";
    }


}
