using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] protected float initialHealth;
    [SerializeField] protected float maxHealth;
    public float Health { get;protected set; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Health = initialHealth;
    }

    public void GetDamege(float quantity)
    {
        if (quantity <= 0)
        {
            return;
        }

        if (Health > 0f)
        {
            Health -= quantity;
            UpdateHealthBar(Health,maxHealth);
            if (Health <= 0)
            {
                Health= 0f;
                UpdateHealthBar(Health, maxHealth);
                CharacterIsDefeated();
            }
        }        
    }

    protected virtual void UpdateHealthBar(float actualHealth, float maxHealth)
    {

    }

    protected virtual void CharacterIsDefeated()
    {

    }
}
