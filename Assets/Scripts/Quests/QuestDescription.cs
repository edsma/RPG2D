using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestDescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questName;
    [SerializeField] private TextMeshProUGUI questDescription;

    public Quest questForUpload { get; set; }

    public virtual void ConfigureQuestUI(Quest questUpload)
    {
        questName.text= questUpload.Name;
        questForUpload = questUpload;
        questDescription.text=questUpload.Description;
    }
}
