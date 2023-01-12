using Assets.Scripts.Dialogs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Common.Constants;

[CreateAssetMenu]
public class NpcDialog : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public Sprite Icon;
    public bool hasExtraInteraction;
    public TypeIntearactionExtraNPC interactionExtra;

    [Header("Saludo")]
    [TextArea] public string greetings;

    [Header("Conversacion")]
    public DialogText[] Conversation;

    [Header("Despedida")]
    [TextArea] public string Goodbye;

}
