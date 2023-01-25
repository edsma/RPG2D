using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Common.Constants;

public class IAController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private CharacterStats stats;

    [Header("Estados")]
    [SerializeField] private IAEstado initialStatus;
    [SerializeField] private IAEstado defaultStatus;

    [Header("Config")]
    [SerializeField] private float rangeDetection;
    [SerializeField] private float rangeAttack;
    [SerializeField] private float velocityMovement;
    [SerializeField] private LayerMask  characterLayerMask;

    [Header("Attack")]
    [SerializeField] private float damage;
    [SerializeField] private float timeBeetwenAttacks;
    [SerializeField] private TypeAttacks typeAttack;

    [Header("Debug")]
    [SerializeField] private bool debug;

    private float timeForNextAttack;

    public Transform characerReference { get;  set; }
    public IAEstado actualStatus { get; private set; }
    public EnemyMovement enemyMovement { get; set; }
    public float RangeDetection => rangeDetection;

    public float Damage => damage;
    public float RangeAttack => rangeAttack;

    private TypeAttacks TypeAttack =>  typeAttack;

    public float VelocityMovement => velocityMovement;

    public LayerMask CharacterLayerMask => characterLayerMask;


    private void Start()
    {
        actualStatus = initialStatus;
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        actualStatus.ExecuteStatus(this);
    }

    public bool CharacterRangeAttack(float range)
    {
        float distanceToCharacter = (characerReference.position - transform.position).magnitude;
        if (distanceToCharacter < Mathf.Pow(range,2))
        {
            return true;
        }

        return false;

    }

    public bool IsTimeForAttack()
    {
        if (Time.time > timeForNextAttack)
        {
            return true;
        }

        return false;
    }

    public void MeleeAttack(float quantity)
    {
        if (characerReference != null)
        {
            ApplyDamageToCharacter(quantity);
        }
    }

    public void ApplyDamageToCharacter(float quantity)
    {
        float damageToApply = 0;
        if (Random.value < stats.percentajeBlock / 100)
        {
            return;
        }

        damageToApply = Mathf.Max(quantity - stats.defense, 1f);
        characerReference.GetComponent<CharacterHealth>().GetDamege(damageToApply);
    }

    public void UpdateTimeBeetwenAttacks()
    {
        timeForNextAttack = Time.time + timeBeetwenAttacks;
    }

    public void ChangeStatus(IAEstado newStatus)
    {
        if (newStatus != defaultStatus)
        {
            actualStatus = newStatus;
        }
    }

    private void OnDrawGizmos()
    {
        if (debug)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position,rangeDetection);
        }
    }
}
