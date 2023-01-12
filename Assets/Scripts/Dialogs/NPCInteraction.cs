using Assets.Scripts.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject npcButtonDialog;
    [SerializeField] private NpcDialog npcDialog;

    public NpcDialog Dialog => npcDialog;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeStatusGameObject(true, collision);
    }

    private void ChangeStatusGameObject(bool status, Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.player))
        {
            DialogManager.Instance.NPCDisponible = (status)? this : null;
            npcButtonDialog.SetActive(status);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ChangeStatusGameObject(false, collision);
    }
}
