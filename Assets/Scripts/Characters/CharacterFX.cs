using Assets.Scripts.IA;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Common.Constants;

public class CharacterFX : MonoBehaviour
{
    [Header("Ppoler")]
    [SerializeField] private ObjectPooler pooler;

    [Header("Config")]
    [SerializeField] private GameObject canvasTextAnimationPrefab;
    [SerializeField] private Transform canvasTextPosition;

    [Header("Type")]
    [SerializeField] private TypeCharacter typeCharacter;

    // Start is called before the first frame update
    private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        pooler.CreatePooler(canvasTextAnimationPrefab);
    }


    private IEnumerator IEShowText(float quantity, Color color)
    {
        GameObject newTextGo = pooler.ObtainInstance();
        TextAnimation text = newTextGo.GetComponent<TextAnimation>();
        text.SetText(quantity,color);
        newTextGo.transform.SetParent(canvasTextPosition);
        newTextGo.transform.position = canvasTextPosition.position;
        newTextGo.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        newTextGo.SetActive(false);
        newTextGo.transform.SetParent(pooler.containerList.transform);
    }

    private void OnEnable()
    {
        IAController.eventDamageDone += AnswerForDamage;
        CharacterAttack.EventEnemyDamage += AnswerDamageToEnemy;
    }

    private void AnswerForDamage(float damage)
    {
        if (typeCharacter.Equals(TypeCharacter.Player))
        {
            StartCoroutine(IEShowText(damage, Color.red));
        }
        
    }

    private void OnDisable()
    {
        IAController.eventDamageDone -= AnswerForDamage;
        CharacterAttack.EventEnemyDamage -= AnswerDamageToEnemy;
    }

    private void AnswerDamageToEnemy(float damage, EnemyHealth enemyHealth)
    {
        if (typeCharacter.Equals(TypeCharacter.IA) && _enemyHealth.Equals(enemyHealth))
        {
            StartCoroutine(IEShowText(damage,Color.white));
        }
    }
}
