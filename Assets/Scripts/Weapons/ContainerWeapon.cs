using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.Common.Constants;

public class ContainerWeapon : Singleton<ContainerWeapon>
{
    [SerializeField] private Image weaponIcon;
    [SerializeField] private Image skillIcon;

    public ItemWeapon equipedWeapon { get; private set; }

    public void EquipArm(ItemWeapon weapon)
    {
        weaponIcon.sprite = weapon.weapon.weaponIcon;
        weaponIcon.gameObject.SetActive(true);
        if (weapon.weapon.type.Equals(WeaponType.Magic))
        {
            skillIcon.sprite = weapon.weapon.skillIcon;
            skillIcon.gameObject.SetActive(true);
        }
        
        Inventario.Instance.character._characterAttack.EquipWeapon(weapon);
    }

    public void RemoveWeapon()
    {
        weaponIcon.gameObject.SetActive(false);
        skillIcon.gameObject.SetActive(false);
        equipedWeapon = null;
        Inventario.Instance.character._characterAttack.RemoveWeapon();
    }
}
