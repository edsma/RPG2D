using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.IA
{
    public class EnemyLoot : MonoBehaviour
    {
        [Header("Exp")]
        [SerializeField] private float wonExp;

        [Header("Root")]
        [SerializeField] private DropItem[] lootAvailable;

        private List<DropItem> lootSelected = new List<DropItem>();
        public List<DropItem> LootSelected => lootSelected;

        public float WonExp => wonExp;

        private void Start()
        {
            SelectLoot();
        }

        private void SelectLoot()
        {
            foreach (DropItem item in lootAvailable)
            {
                float probability = Random.Range(0,100);
                if (probability <= item.PercentajeDrop)
                {
                    lootSelected.Add(item);
                }
            }
        }
    }
}
