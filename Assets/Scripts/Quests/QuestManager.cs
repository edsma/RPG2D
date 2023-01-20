using Assets.Scripts.Characters;
using Assets.Scripts.Quests;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : Singleton<QuestManager>
{
    [Header("Character")]
    [SerializeField] private Character character;

    [Header("Quests")]
    [SerializeField] private Quest[] availableQuests;

    [Header("Inspecto Quests")]
    [SerializeField] private InspectorQuestDescription inspectorQuestPrefab;
    [SerializeField] private Transform inspectorQuestContainer;

    [Header("Inspecto Quests")]
    [SerializeField] private CharacterQuestDescription characterQuestprefab;
    [SerializeField] private Transform characterQuestContainer;

    [Header("Panel Quest")]
    [SerializeField] private GameObject panelQuestCompleted;
    [SerializeField] private TextMeshProUGUI questName;
    [SerializeField] private TextMeshProUGUI questRewardGold;
    [SerializeField] private TextMeshProUGUI questRewardExp;
    [SerializeField] private TextMeshProUGUI questRewardItemQuantity;
    [SerializeField] private Image questRewardIcon;
    public Quest QuestForReclaim { get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        UploadQuestInspector();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            AddProgress("Kill10", 1);
            AddProgress("Kill25", 1);
            AddProgress("Kill50", 1);
        }
    }

    private void UploadQuestInspector()
    {
        for (int i = 0; i < availableQuests.Length; i++)
        {
            InspectorQuestDescription  newQuest =  Instantiate(inspectorQuestPrefab, inspectorQuestContainer);
            newQuest.ConfigureQuestUI(availableQuests[i]);
        }
    }

    private void AddQuestForComplete(Quest questForComplete)
    {
        CharacterQuestDescription newQuest = Instantiate(characterQuestprefab, characterQuestContainer);
        newQuest.ConfigureQuestUI(questForComplete);
    }

    public void AddQuest(Quest questForComplete)
    {
        AddQuestForComplete(questForComplete);
    }

    public void AddProgress(string questId, int quantity)
    {
        Quest questForUpdate = QuestExist(questId);
        questForUpdate.AddProgress(quantity);
    }


    private void ShowQuestCompleted(Quest questCompleted)
    {
        panelQuestCompleted.SetActive(true);
        questName.text = questCompleted.Name;
        questRewardGold.text = questCompleted.rewardGold.ToString();
        questRewardExp.text = questCompleted.rewardExp.ToString();
        questRewardItemQuantity.text = questCompleted.questRewardItem.quantity.ToString();
        questRewardIcon.sprite = questCompleted.questRewardItem.item.Icon;
    }

    public void ReclaimReward()
    {
        if (QuestForReclaim == null)
        {
            return;
        }
        CoinsManager.Instance.AddCoins(QuestForReclaim.rewardGold);
        character.characterExp.AddExp(QuestForReclaim.rewardExp);
        Inventario.Instance.AddItem(QuestForReclaim.questRewardItem.item, QuestForReclaim.questRewardItem.quantity);
        panelQuestCompleted.SetActive(false);
        QuestForReclaim= null;
    }

    private void QuestCompletedAnswer(Quest completedQuest)
    {
        QuestForReclaim = QuestExist(completedQuest.Id);
        if (QuestForReclaim != null)
        {
            ShowQuestCompleted(QuestForReclaim);
        }
    }

    private void OnEnable()
    {
        Quest.eventQuest += QuestCompletedAnswer;
    }

    private void OnDisable()
    {
        Quest.eventQuest -= QuestCompletedAnswer;
    }

    private Quest QuestExist(string questId)
    {
        for (int i = 0; i < availableQuests.Length; i++)
        {
            if (availableQuests[i].Id.Equals(questId))
            {
                return availableQuests[i];
            }
        }
        return null;
    }
}
