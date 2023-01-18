using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public  class InspectorQuestDescription: QuestDescription
    {
        [SerializeField] private TextMeshProUGUI questReward;
        public override void ConfigureQuestUI(Quest questUpload)
        {
            base.ConfigureQuestUI(questUpload);
            questForUpload = questUpload;
            questReward.text = $"-{questUpload.rewardGold} gold  {Environment.NewLine}" + 
                $"-{questUpload.rewardExp} {Environment.NewLine}" +
                $"-{questUpload.questRewardItem.item.Name} x{questUpload.questRewardItem.quantity} {Environment.NewLine}" ;
        }



        public void AceptQuest()
        {
            if (questForUpload == null)
            {
                return;
            }

            QuestManager.Instance.AddQuest(questForUpload);
            gameObject.SetActive(false);
        }
    }
}
