using System;
using UnityEngine;
using static Assets.Scripts.Common.Constants;

public class AtributteButton : MonoBehaviour
{

    public static Action<TypeAtributte> addEventAtributte;
    [SerializeField] private TypeAtributte type;


    public void addAtribbute()
    {
        addEventAtributte?.Invoke(type);
    }


}
