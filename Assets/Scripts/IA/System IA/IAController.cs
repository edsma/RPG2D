using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Common.Constants;

public class IAController : MonoBehaviour
{
    public static Action<float> eventDamageDone;

    [Header("Stats")]
    [SerializeField] private CharacterStats stats;

    [Header("Estados")]
    [SerializeField] private IAEstado initialStatus;
    [SerializeField] private IAEstado defaultStatus;

    [Header("Config")]
    [SerializeField] private float rangeDetection;
    [SerializeField] private float rangeAttack;
    [SerializeField] private float rangeEmbestida;

    [SerializeField] private float velocityMovement;
    [SerializeField] private float velocityEmbestida;
    [SerializeField] private LayerMask  characterLayerMask;

    [Header("Attack")]
    [SerializeField] private float damage;
    [SerializeField] private float timeBeetwenAttacks;
    [SerializeField] private TypeAttacks typeAttack;

    [Header("Debug")]
    [SerializeField] private bool debug;
    [SerializeField] private bool debugEmbestida;

    private float timeForNextAttack;
    private BoxCollider2D _boxCollider2D;

    public Transform characerReference { get;  set; }
    public IAEstado actualStatus { get; private set; }
    public EnemyMovement enemyMovement { get; set; }
    public float RangeDetection => rangeDetection;

    public float Damage => damage;
    public float RangeAttack => rangeAttack;

    public TypeAttacks TypeAttack =>  typeAttack;

    public float VelocityMovement => velocityMovement;

    public LayerMask CharacterLayerMask => characterLayerMask;

    public float rangeOfAttackInitial => typeAttack == TypeAttacks.Embestida ? rangeEmbestida : rangeAttack;


    private void Start()
    {
        _boxCollider2D= GetComponent<BoxCollider2D>();  
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

    public void AttackEmbestida(float quantity)
    {
        StartCoroutine(IEEmbestida(quantity));
    }

    private IEnumerator IEEmbestida(float quantity)
    {
        Vector3 characterPosition = characerReference.position;
        Vector3 initialPosition = transform.position;
        Vector3 directionCharacter = (characterPosition - initialPosition).normalized;
        Vector3 positionOfAttack = characterPosition - directionCharacter * 0.5f;
        _boxCollider2D.enabled = false;

        float transitionAttack = 0f;
        while (transitionAttack <= 1f)
        {
            transitionAttack += Time.deltaTime * velocityMovement;
            float interpolation = (-Mathf.Pow(transitionAttack, 2) + transitionAttack) * 4f;
            transform.position = Vector3.Lerp(initialPosition, positionOfAttack, interpolation);
            yield return null;
        }

        if (characerReference != null)
        {
            ApplyDamageToCharacter(quantity);
        }
        _boxCollider2D.enabled = true;
    }

    public void ApplyDamageToCharacter(float quantity)
    {
        float damageToApply = 0;
        if (UnityEngine.Random.value < stats.percentajeBlock / 100)
        {
            return;
        }

        damageToApply = Mathf.Max(quantity - stats.defense, 1f);
        characerReference.GetComponent<CharacterHealth>().GetDamege(damageToApply);
        eventDamageDone?.Invoke(damageToApply);
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

        if (debugEmbestida)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, rangeAttack);
            Gizmos.DrawWireSphere(transform.position, rangeEmbestida);
        }
    }
}
