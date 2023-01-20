using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterQuestDescription : QuestDescription
{
    [SerializeField] private TextMeshProUGUI rewardGold;
    [SerializeField] private TextMeshProUGUI rewardExp;
    [SerializeField] private TextMeshProUGUI targetTask;
    
    [Header("Item")]
    [SerializeField] private Image iconRewardItem;
    [SerializeField] private TextMeshProUGUI rewardItemQuantity;


    private void Update()
    {
        targetTask.text = $"{questForUpload.actualQquantity}/{questForUpload.quantityTarget}";
    }

    public override void ConfigureQuestUI(Quest questUpload)
    {
        base.ConfigureQuestUI(questUpload);
        rewardGold.text = questUpload.rewardGold.ToString();
        rewardExp.text = questUpload.rewardExp.ToString();
        targetTask.text = $"{questUpload.actualQquantity}/{questUpload.quantityTarget}";

        iconRewardItem.sprite = questUpload.questRewardItem.item.Icon;
        rewardItemQuantity.text = questUpload.questRewardItem.quantity.ToString();
    }

    private void OnEnable()
    {
        if (questForUpload.questCompletedCheck)
        {
            gameObject.SetActive(false);
        }
        Quest.eventQuest += QuestCompletedAnswer;
    }

    private void QuestCompletedAnswer(Quest questCompleted)
    {
        if (questCompleted.Id.Equals(questForUpload.Id))
        {
            targetTask.text = $"{questForUpload.actualQquantity}/{questForUpload.quantityTarget}";
        }
    }

    private void OnDisable()
    {
        Quest.eventQuest += QuestCompletedAnswer;
    }


}
