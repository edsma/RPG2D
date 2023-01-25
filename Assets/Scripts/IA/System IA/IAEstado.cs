using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IA/Status")]
public class IAEstado : ScriptableObject
{
    public IAAction[] actions;
    public AITransicion[] transactions;

    public void ExecuteStatus(IAController controller)
    {
        ExecuteActions(controller);
        MakeTransaction(controller);
    }

    private void ExecuteActions(IAController controller)
    {
        if (actions == null || actions.Length <= 0)
        {
            return;
        }

        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Execute(controller);
        }
    }

    private void MakeTransaction(IAController controller)
    {
        if (transactions == null || transactions.Length <= 0)
        {
            return;
        }

        for (int i = 0; i < transactions.Length; i++)
        {
            bool desitionValue = transactions[i].Decision.Choose(controller);
            if (desitionValue)
            {
                controller.ChangeStatus(transactions[i].EstadoVerdadero);
            }
            else
            {
                controller.ChangeStatus(transactions[i].EstadoFalso);
            }
        }
    }
}
