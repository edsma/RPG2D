using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IA/Decitions/Personaje en rango de ataque")]
public class DecitionCharacterRangeAttack : IADecision
{
    public override bool Choose(IAController controller)
    {
        return InRangeOfAttack(controller);
    }

    private bool InRangeOfAttack(IAController controller)
    {
        if (controller.characerReference == null)
        {
            return false;
        }

        float distance = (controller.characerReference.position - controller.transform.position).sqrMagnitude;
        if (distance < Mathf.Pow(controller.RangeAttack,1))
        {
            return true;
        }

        return false;
    }
}
