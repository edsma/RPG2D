using UnityEngine;
using UnityEngine.UI;

public class EnemyBarLife : MonoBehaviour
{
    [SerializeField] private Image barLife;

    private float actualHealth;
    private float maxHealth;


    private void Update()
    {
        barLife.fillAmount = Mathf.Lerp(barLife.fillAmount,actualHealth/maxHealth, 1.0f* Time.deltaTime);

    }

    public void UpdateHealthEnemy(float pActualHealth, float pMaxHealth)
    {
        actualHealth= pActualHealth;
        maxHealth= pMaxHealth;  
    }
}
