using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : Singleton<DialogManager>
{
    [SerializeField] private GameObject panelDialog;
    [SerializeField] private Image npcIcon;
    [SerializeField] private TextMeshProUGUI npcNameTMP;
    [SerializeField] private TextMeshProUGUI npcConversationTMP;

    public NPCInteraction NPCDisponible { get;  set; }
    private Queue<string> sequenceDialog;
    private bool animationDialog;
    private bool showGoodBye;

    private void Start()
    {
        sequenceDialog= new Queue<string>();
    }

    public void OpenCloseDialogPanel(bool status)
    {
        panelDialog.SetActive(status);
    }

    private void Update()
    {
        if (NPCDisponible == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ConfigurePanel(NPCDisponible.Dialog);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (showGoodBye)
            {
                OpenCloseDialogPanel(false);
                showGoodBye=false;
                return;
            }

            if (NPCDisponible.Dialog.hasExtraInteraction)
            {
                UIManager.Instance.OpenPanelInteraction(NPCDisponible.Dialog.interactionExtra);
                OpenCloseDialogPanel(false);
                return;
            }

            if (animationDialog)
            {
                ContinueDialog();
            }
        }
    }


    private void ContinueDialog()
    {
        if (NPCDisponible == null)
        {
            return;
        }

        if (showGoodBye) {
            return;
        }

        if (sequenceDialog.Count == 0)
        {
            string bye = NPCDisponible.Dialog.Goodbye;
            ShowTextWithAnimation(bye);
            showGoodBye = true;
            return;
        }

        if (sequenceDialog.Count > 0)
        {
            string nextDialog = sequenceDialog.Dequeue();
            ShowTextWithAnimation(nextDialog);
        }
        
      
    }

    private void ConfigurePanel(NpcDialog npcDialog)
    {
        OpenCloseDialogPanel(true);
        UploadDialogSequence(npcDialog);
        npcIcon.sprite = npcDialog.Icon;
        npcNameTMP.text = $"{npcDialog.Name}";
        ShowTextWithAnimation(npcDialog.greetings);
    }

    private void UploadDialogSequence(NpcDialog npcDialog)
    {
        if (npcDialog.Conversation == null || npcDialog.Conversation.Length <=0)
        {
            return;
        }

        for (int i = 0; i < npcDialog.Conversation.Length; i++)
        {
            sequenceDialog.Enqueue(npcDialog.Conversation[i].text);
        }
    }

    private IEnumerator AnimateText(string oration)
    {
        animationDialog = false;
        npcConversationTMP.text = "";
        char[] letters = oration.ToCharArray();
        for (int i = 0; i < letters.Length; i++)
        {
            npcConversationTMP.text += letters[i];
            yield return new WaitForSeconds(0.03f);
        }
        animationDialog = true;
    }

    void ShowTextWithAnimation(string oration)
    {
        StartCoroutine(AnimateText(oration));   
    }

}
