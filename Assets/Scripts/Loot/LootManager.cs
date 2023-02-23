using Assets.Scripts.IA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : Singleton<LootManager>
{
    [Header("Config")]
    [SerializeField] private GameObject panelLoot;

    [SerializeField] private LootButton lootButtonPrefab;
    [SerializeField] private Transform lootContainer;

   public void ShowLoot(EnemyLoot enemyLoot)
    {
        panelLoot.SetActive(true);
        if (ContainerIsNotAvailable())
        {
            foreach (Transform children in lootContainer.transform)
            {
                Destroy(children.gameObject);
            }
        }

        for (int i = 0; i < enemyLoot.LootSelected.Count; i++)
        {
            UploadLootPanel(enemyLoot.LootSelected[i]);
        }
    }

    private void UploadLootPanel(DropItem dropItem)
    {
        if (dropItem.ItemPickeUp)
        {
            return;
        }

        LootButton loot = Instantiate(lootButtonPrefab, lootContainer);
        loot.ConfigureLootItem(dropItem);
        loot.transform.SetParent(lootContainer);
    }

    private bool ContainerIsNotAvailable()
    {
        LootButton[] children = lootContainer.GetComponentsInChildren<LootButton>();
        if (children.Length > 0)
        {
            return true;
        }
        return false;
    }
}
