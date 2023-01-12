using System;
using UnityEngine;

namespace Assets.Scripts
{
    public  class CharacterHealth:BaseHealth
    {
        public bool IsCharacterDefeated { get; set; }
        public bool cantBeCured => Health < maxHealth;
        private BoxCollider2D _boxCollider2D;

        private void Awake()
        {
            _boxCollider2D= GetComponent<BoxCollider2D>();
        }

        public static Action EventCharacterDefeated;


        protected override void Start()
        {
            base.Start();
            UpdateHealthBar(Health, maxHealth);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                GetDamege(10);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                RestaurateHealth(10);
            }
        }

        public void RestaurateHealth(float quantity)
        {
            if (IsCharacterDefeated)
            {
                return;
            }

            if(cantBeCured)
            {
                Health += quantity;
                if (Health > maxHealth)
                {
                    Health = maxHealth;
                }
                UpdateHealthBar(Health, maxHealth);
            }
        }

        protected override void CharacterIsDefeated()
        {
            _boxCollider2D.enabled = false;
            IsCharacterDefeated = true;
            EventCharacterDefeated?.Invoke();
        }

        public void RestartCharacter()
        {
            _boxCollider2D.enabled= true;
            IsCharacterDefeated = false;
            Health = initialHealth;
            UpdateHealthBar(Health, initialHealth);
        }

        protected override void UpdateHealthBar(float actualHealth, float maxHealth)
        {
            UIManager.Instance.UpdateHealthForCharacter(actualHealth, maxHealth);
        }
    }
}
