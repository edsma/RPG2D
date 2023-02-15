using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.IA
{
    internal class EnemyHealth: BaseHealth
    {
        [SerializeField] private EnemyBarLife barLifePrefab;
        [SerializeField] private Transform barLifePosition;

        private EnemyBarLife _enemyBarLifeCreate;
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _boxCollider2D;
        private IAController _controller;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider2D= GetComponent<BoxCollider2D>();
            _controller = GetComponent<IAController>(); 

        }

        protected override void Start()
        {
            base.Start();
            CreateBarLife();
        }

        private void CreateBarLife()
        {
            _enemyBarLifeCreate = Instantiate(barLifePrefab, barLifePosition);
            UpdateHealthBar(Health, maxHealth);
        }

        protected override void UpdateHealthBar(float actualHealth, float maxHealth)
        {
            _enemyBarLifeCreate.UpdateHealthEnemy(actualHealth, maxHealth);
        }
    }
}
