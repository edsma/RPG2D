using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.Common.Constants;

public class UIManager : Singleton<UIManager>
{
    [Header("stats")]
    [SerializeField] private CharacterStats stats;


    [Header("Panel ")]
    [SerializeField] private GameObject panelStats;
    [SerializeField] private GameObject panelInventory;
    [SerializeField] private GameObject panelInspectoQuests;
    [SerializeField] private GameObject panelCharacterQuests;


    [Header("Bar")]
    [SerializeField] private Image playerHealth;
    [SerializeField] private Image playerMana;
    [SerializeField] private Image playerExp;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI healthTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;
    [SerializeField] private TextMeshProUGUI expTMP;
    [SerializeField] private TextMeshProUGUI levelTMP;

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI statDamageTmp;
    [SerializeField] private TextMeshProUGUI statDefenseTmp;
    [SerializeField] private TextMeshProUGUI statCriticTmp;
    [SerializeField] private TextMeshProUGUI statBlockTmp;
    [SerializeField] private TextMeshProUGUI statVelocityTmp;
    [SerializeField] private TextMeshProUGUI statLevelTmp;
    [SerializeField] private TextMeshProUGUI statExpTmp;
    [SerializeField] private TextMeshProUGUI statExpRequiredTmp;
    [SerializeField] private TextMeshProUGUI statStrenghtAtribbuteTmp;
    [SerializeField] private TextMeshProUGUI statIntelligenceAtribbuteTmp;
    [SerializeField] private TextMeshProUGUI statDestrezaAtribbuteTmp;
    [SerializeField] private TextMeshProUGUI statPointAvailableAtribbuteTmp;

    private float actualHealth;
    private float maxHealth;
    private float expRequiredForNextLevel;

    private float actualMana;
    private float maxMana;
    private float actualExp;




    // Update is called once per frame
    void Update()
    {
        UpdateUICharacter();
        UpdatePanelStats();
    }

    void UpdateUICharacter()
    {
        playerHealth.fillAmount = Mathf.Lerp(playerHealth.fillAmount, actualHealth / maxHealth, 10f * Time.deltaTime);
        playerMana.fillAmount = Mathf.Lerp(playerMana.fillAmount, actualMana / maxMana, 10f * Time.deltaTime);
        playerExp.fillAmount = Mathf.Lerp(playerExp.fillAmount, actualExp / expRequiredForNextLevel, 10f * Time.deltaTime);
        healthTMP.text = $"{actualHealth} / {maxHealth}";
        manaTMP.text = $"{Convert.ToInt32(actualMana)} / {maxMana}";
        expTMP.text = $"{actualExp} / {expRequiredForNextLevel}";
        levelTMP.text = $"Level: {stats.Level}";
    }

    private void UpdatePanelStats()
    {
        if (!panelStats.activeSelf)
        {
            return;
        }

        statDamageTmp.text = stats.damage.ToString();
        statDefenseTmp.text = stats.defense.ToString();
        statVelocityTmp.text = stats.Velocity.ToString();
        statLevelTmp.text = stats.Level.ToString();
        statExpTmp.text = stats.ExpActual.ToString();
        statExpRequiredTmp.text = stats.ExpForNextLevel.ToString();
        statBlockTmp.text = stats.percentajeBlock.ToString();
        statCriticTmp.text = stats.percentajeForCritic.ToString();
        statStrenghtAtribbuteTmp.text = stats.Strenght.ToString();
        statPointAvailableAtribbuteTmp.text = $"Points available: {stats.pointAvailable.ToString()}";
        statIntelligenceAtribbuteTmp.text = stats.Intelligence.ToString();
        statDestrezaAtribbuteTmp.text = stats.Destreza.ToString();
    }

    public void UpdateHealthForCharacter(float pActualHealth, float pMaxHealth)
    {
        actualHealth = pActualHealth;
        maxHealth = pMaxHealth;
    }

    public void UpdateManaForCharacter(float pActualMana, float pMaxMana)
    {
        actualMana = pActualMana;
        maxMana = pMaxMana;
    }

    public void UpdateExpForCharacter(float pActualExp, float pMExpRequired)
    {
        actualExp = pActualExp;
        expRequiredForNextLevel = pMExpRequired;
    }

    #region Panels
    public void OpenClosePanelStats()
    {
        panelStats.SetActive(!panelStats.activeSelf);
    }

    public void OpenClosePanelInventory()
    {
        panelInventory.SetActive(!panelInventory.activeSelf);
    }

    public void OpenClosePanelCharacterQuest()
    {
        panelCharacterQuests.SetActive(!panelCharacterQuests.activeSelf);
    }


    public void OpenClosePanelQuests()
    {
        panelInspectoQuests.SetActive(!panelInspectoQuests.activeSelf);
    }

    public void OpenPanelInteraction(TypeIntearactionExtraNPC typeInteraction)
    {
        switch (typeInteraction)
        {
            case TypeIntearactionExtraNPC.Quests:
                OpenClosePanelQuests();
                break;
            case TypeIntearactionExtraNPC.store:
                break;
            case TypeIntearactionExtraNPC.crafting:
                break;
            default:
                break;
        }
    }

    #endregion
}
