using System;
using UnityEngine;
using static Assets.Scripts.Common.Constants;

public class CharacterAttack : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private CharacterStats stats;

    
    public Weapon equipedWeapon { get; private set; }
    public EnemyInteraction EnemyTarget { get; private set; }

    [Header("Pooler")]
    [SerializeField] private ObjectPooler pooler;



    public void EquipWeapon(ItemWeapon weaponToEquip)
    {
        equipedWeapon = weaponToEquip.weapon;
        if (equipedWeapon.type.Equals(WeaponType.Magic))
        {
            pooler.CreatePooler(equipedWeapon.proyectilPrefab.gameObject);
        }
        stats.AddBonusForWeapon(weaponToEquip.weapon);
    }

    public void RemoveWeapon()
    {
        if (equipedWeapon == null)
        {
            return;
        }

        if (equipedWeapon.type.Equals(WeaponType.Magic))
        {
            pooler.DestroyPooler();
        }
        stats.RemoveBonusForWeapon(equipedWeapon);
        equipedWeapon = null;
    }
    private void EnemyRangeSelected(EnemyInteraction enemySelected)
    {
        if (enemySelected == null)
        {
            return;
        }

        if (equipedWeapon.type != WeaponType.Magic)
        {
            return;
        }

        if (EnemyTarget == enemySelected)
        {
            return;
        }

        EnemyTarget = enemySelected;
        EnemyTarget.ShowEnemySelected(true);
    }

    private void EnemyNoSelected()
    {
        if (EnemyTarget == null)
        {
            return;
        }

        EnemyTarget.ShowEnemySelected(false);
        EnemyTarget = null;
    }

    private void OnEnable()
    {
        SelectionManager.eventEnemySelected += EnemyRangeSelected;
        SelectionManager.eventObjectNoSelected += EnemyNoSelected;
    }

    

    private void OnDisable()
    {
        SelectionManager.eventEnemySelected -= EnemyRangeSelected;
        SelectionManager.eventObjectNoSelected += EnemyNoSelected;
    }
}
