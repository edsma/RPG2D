using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Common.Constants;

[CreateAssetMenu(menuName = "Character/Weapon")]
public class Weapon : ScriptableObject
{
    [Header("Config")]
    public Sprite weaponIcon;
    public Sprite skillIcon;
    public WeaponType type;
    public float damage;

    [Header("Magic Weapon")]
    public Proyectil proyectilPrefab;
    public float manaRequired;

    [Header("Stats")]
    public float criticDamage;
    public float blockPosibility;

}
