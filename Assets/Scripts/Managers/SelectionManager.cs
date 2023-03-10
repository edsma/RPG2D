using Assets.Scripts.Common;
using Assets.Scripts.IA;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static Action<EnemyInteraction> eventEnemySelected;
    public static Action eventObjectNoSelected;

    public EnemyInteraction enemySelected { get; set; }

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera= Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        SelectEnemy();
    }

    private void SelectEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,Mathf.Infinity,LayerMask.GetMask(Constants.Tags.enemy));
            if (hit.collider != null)
            {
                enemySelected = hit.collider.GetComponent<EnemyInteraction>();
                EnemyHealth enemyHealth = enemySelected.GetComponent<EnemyHealth>();
                if (enemyHealth.Health > 0 )
                {
                    eventEnemySelected?.Invoke(enemySelected);
                }
                else
                {
                    EnemyLoot loot = enemySelected.GetComponent<EnemyLoot>();
                    LootManager.Instance.ShowLoot(loot);
                }
            }
            else
            {
                eventObjectNoSelected?.Invoke();
            }
        }
    }
}
