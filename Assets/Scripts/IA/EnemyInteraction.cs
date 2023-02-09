using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    [SerializeField] private GameObject selectionFX;

    public void ShowEnemySelected(bool status)
    {
        selectionFX.SetActive(status);
    }
}
