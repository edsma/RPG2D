using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Common.Constants;

public class EnemyInteraction : MonoBehaviour
{
    [SerializeField] private GameObject selectionFX;
    [SerializeField] private GameObject selectionMeleeFx;

    public void ShowEnemySelected(bool status, TypeDetection type)
    {
        switch (type)
        {
            case TypeDetection.Range:
                selectionFX.SetActive(status);
                break;
            case TypeDetection.Melee:
                selectionMeleeFx.SetActive(status);
                break;
            default:
                break;
        }
        
    }
}
