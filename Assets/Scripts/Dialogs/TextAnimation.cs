using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damageText;

    public void SetText(float quantity, Color color)
    {
        damageText.text = quantity.ToString();
        damageText.color= color;
    }
}
