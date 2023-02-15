using Assets.Scripts.Common;
using Assets.Scripts.Weapons;
using System;
using System.Collections;
using UnityEngine;
using static Assets.Scripts.Common.Constants;

public class CharacterAttack : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private CharacterStats stats;

    
    public Weapon equipedWeapon { get; private set; }
    public EnemyInteraction EnemyTarget { get; private set; }

    private int indexDirectionShoot;
    private ManaCharacter _manaCharacter;
    private float timeForNextAttack;
    public bool isAttacking;

    private void Awake()
    {
        _manaCharacter= GetComponent<ManaCharacter>();
    }

    [Header("Pooler")]
    [SerializeField] private ObjectPooler pooler;

    [Header("Attack")]
    [SerializeField] private Transform[] positionShoot;
    [SerializeField] private float timeBeetwenAttacks;


    private void Update()
    {
        ObtainDirectionShoot();
        if (Time.time > timeForNextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (equipedWeapon == null || EnemyTarget == null)
                {
                    return;
                }

                UseWeapon();
                timeForNextAttack = Time.time + timeBeetwenAttacks;
                StartCoroutine(IEEstableAttackCondition());
            }
        }
    }

    private IEnumerator IEEstableAttackCondition()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.3f);
        isAttacking= false;
    }

    private void UseWeapon()
    {
        if (equipedWeapon.type.Equals(WeaponType.Magic) )
        {
            if (_manaCharacter.ActualMana < equipedWeapon.manaRequired)
            {

                return;
            }
            GameObject newProyectile = pooler.ObtainInstance();
            newProyectile.transform.localPosition = positionShoot[indexDirectionShoot].position;

            Proyectil proyectil = newProyectile.GetComponent<Proyectil>();
            proyectil.InitializeProyectil(EnemyTarget);

            newProyectile.SetActive(true);
            _manaCharacter.UseMana(equipedWeapon.manaRequired);

        }
    }

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

    private void ObtainDirectionShoot()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw(Constants.Axis.horizontal), Input.GetAxisRaw(Constants.Axis.vertical));
        if (input.x > 0.1f)
        {
            indexDirectionShoot = 1;
        }else if (input.x < 0f)
        {
            indexDirectionShoot = 3;
        }else if (input.y > 0.1f)
        {
            indexDirectionShoot = 0;
        }else if (input.y< 0f)
        {
            indexDirectionShoot = 2;
        }
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
        EnemyTarget.ShowEnemySelected(true,TypeDetection.Range);
    }

    private void EnemyNoSelected()
    {
        if (EnemyTarget == null)
        {
            return;
        }

        EnemyTarget.ShowEnemySelected(false, TypeDetection.Range);
        EnemyTarget = null;
    }

    private void EnemyMeleeDetec(EnemyInteraction enemyTarget)
    {
        if (equipedWeapon == null){return;}
        if (equipedWeapon.type != WeaponType.Melee){ return;}
        EnemyTarget = enemyTarget;
        enemyTarget.ShowEnemySelected(true, TypeDetection.Melee);
    }

    private void EnemyMeleeLost()
    {
        if (equipedWeapon == null) { return; }
        if (EnemyTarget == null) { return; }
        if (equipedWeapon.type != WeaponType.Melee) { return; }
        EnemyTarget.ShowEnemySelected(false, TypeDetection.Melee);
        EnemyTarget = null;
    }

    private void OnEnable()
    {
        SelectionManager.eventEnemySelected += EnemyRangeSelected;
        SelectionManager.eventObjectNoSelected += EnemyNoSelected;
        CharacterDetector.eventEnemyDectection += EnemyMeleeDetec;
        CharacterDetector.eventEnemyLost+=  EnemyMeleeLost;
    }  

    private void OnDisable()
    {
        SelectionManager.eventEnemySelected -= EnemyRangeSelected;
        SelectionManager.eventObjectNoSelected -= EnemyNoSelected;
        CharacterDetector.eventEnemyDectection -= EnemyMeleeDetec;
        CharacterDetector.eventEnemyLost -= EnemyMeleeLost;
    }

    
}
