using Assets.Scripts.Common;
using Assets.Scripts.IA;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class Proyectil: MonoBehaviour
    {
        [Header("Config")]
        [SerializeField]
        private float velocity;

        public CharacterAttack characterAttack { get; private set; }
        private Rigidbody2D _rigifBody2D;
        private Vector2 direction;
        private EnemyInteraction enemyTarget;


        private void Awake()
        {
            _rigifBody2D= GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (enemyTarget == null)
            {
                return;
            }

            MoveProyectile();
        }

        private void MoveProyectile()
        {
            direction = enemyTarget.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
            _rigifBody2D.MovePosition(_rigifBody2D.position + direction.normalized * velocity * Time.fixedDeltaTime);
        }

        public void InitializeProyectil(CharacterAttack enemy)
        {
            characterAttack = enemy;
            enemyTarget= enemy.EnemyTarget;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Constants.Tags.enemy))
            {
                float damage = characterAttack.ObtainDamage();
                enemyTarget.GetComponent<EnemyHealth>().GetDamege(damage);
                CharacterAttack.eventEnemyDamage?.Invoke(damage);
                gameObject.SetActive(false);
            }
        }

    }
}
