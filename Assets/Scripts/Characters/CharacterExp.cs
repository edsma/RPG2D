using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterExp : MonoBehaviour
{
    [Header("Stas")]
    [SerializeField] private CharacterStats stats;

    [Header("Config")]
    [SerializeField] private int levelMax;
    [SerializeField] private int expBase;
    [SerializeField] private int incrementalValue;


    public int Level { get; private set; }

    private float expActual;
    private float expActualTemp;
    private float expRequiredNextLevel;
    // Start is called before the first frame update
    void Start()
    {
        Level = 6;
        stats.Level = 1;
        expRequiredNextLevel = expBase;
        UpdateBarExp();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddExp(10);
        }
    }

    // Update is called once per frame
    public void AddExp(float expObtain)
    {
        if (expObtain > 0f)
        {
            float expForNextLevel = expRequiredNextLevel - expActualTemp;
            if (expObtain >= expForNextLevel)
            {
                expObtain -= expForNextLevel;
                expActual += expObtain;
                UpdateLevel();
                AddExp(expObtain);
            }
            else
            {
                expActual += expObtain;
                expActualTemp += expObtain;
                if (expActualTemp.Equals(expForNextLevel))
                {
                    UpdateLevel();
                }
            }
        }
        stats.ExpActual= expActual;
        UpdateBarExp();
    }

    void UpdateLevel()
    {
        if (stats.Level < levelMax)
        {
            Level++;
            expActualTemp = 0f;
            expRequiredNextLevel *= incrementalValue;
            stats.ExpForNextLevel = expRequiredNextLevel;
            stats.pointAvailable += 3;
            stats.Level++;
        }
    }

    private void UpdateBarExp()
    {
        UIManager.Instance.UpdateExpForCharacter(expActualTemp,expRequiredNextLevel);
    }
}
