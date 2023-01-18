using Assets.Scripts.Quests;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [Header("Quests")]
    [SerializeField] private Quest[] availableQuests;

    [Header("Inspecto Quests")]
    [SerializeField] private InspectorQuestDescription inspectorQuestPrefab;
    [SerializeField] private Transform inspectorQuestContainer;

    [Header("Inspecto Quests")]
    [SerializeField] private CharacterQuestDescription characterQuestprefab;
    [SerializeField] private Transform characterQuestContainer;



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
