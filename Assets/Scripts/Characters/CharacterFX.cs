using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFX : MonoBehaviour
{
    [SerializeField] private GameObject canvasTextAnimationPrefab;
    [SerializeField] private Transform canvasTextPosition;

    private ObjectPooler pooler;
    // Start is called before the first frame update
    void Awake()
    {
        pooler= GetComponent<ObjectPooler>();
    }

    private void Start()
    {
        pooler.CreatePooler(canvasTextAnimationPrefab);
    }

    private IEnumerator IEShowText(float quantity)
    {
        GameObject newTextGo = pooler.ObtainInstance();
        TextAnimation text = newTextGo.GetComponent<TextAnimation>();
        text.SetText(quantity);
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
    }

    private void AnswerForDamage(float damage)
    {
        StartCoroutine(IEShowText(damage));
    }

    private void OnDisable()
    {
        IAController.eventDamageDone -= AnswerForDamage;
    }
}
