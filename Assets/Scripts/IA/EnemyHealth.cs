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
        [Header("Life")]
        [SerializeField] private EnemyBarLife barLifePrefab;
        [SerializeField] private Transform barLifePosition;

        [Header("Rastros")]
        [SerializeField] private GameObject rastros;

        private EnemyBarLife _enemyBarLifeCreate;
        private EnemyInteraction _enemyInteraction;
        private EnemyMovement _enemyMovement;
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _boxCollider2D;
        private IAController _controller;

        private void Awake()
        {
            _enemyInteraction= GetComponent<EnemyInteraction>();
            _enemyMovement= GetComponent<EnemyMovement>();
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

        protected override void CharacterIsDefeated()
        {
            DesativeEnemy();
        }

        private void DesativeEnemy()
        {
            rastros.SetActive(true);
            _enemyBarLifeCreate.gameObject.SetActive(false);
            _spriteRenderer.enabled= false;
            _enemyMovement.enabled= false;
            _controller.enabled= false;
            _boxCollider2D.isTrigger= true;
            _enemyInteraction.DesactiveSpriteSelection();
        }
    }
}
