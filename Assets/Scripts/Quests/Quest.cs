using Assets.Scripts.Quests;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Quest : ScriptableObject
{

    public static Action<Quest> eventQuest;
    [Header("Info")]
    public string Name;
    public string Id;
    public int quantityTarget;

    [Header("Description")]
    [TextArea] public string Description;

    [Header("Rewards")]
    public int rewardGold;
    public int rewardExp;
    public QuestRewardItem questRewardItem;


    public bool questCompletedCheck = false;

    public int actualQquantity;



    public void AddProgress(int quantity)
    {
        actualQquantity += quantity;
        ValidateQuestIsCompleted();
    }

    private void ValidateQuestIsCompleted()
    {
        if (actualQquantity >= quantityTarget)
        {
            actualQquantity = quantityTarget;
            QuestCompleted();
        }
    }

    private void QuestCompleted()
    {
        if (questCompletedCheck)
        {
            return;
        }

        questCompletedCheck = true;
        eventQuest?.Invoke(this);
    }


}
