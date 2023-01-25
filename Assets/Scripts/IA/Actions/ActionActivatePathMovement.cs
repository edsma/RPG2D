using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IA/Acciones/Activar camino movimiento")]
public class ActionActivatePathMovement : IAAction
{
    public override void Execute(IAController controller)
    {
        if (controller.enemyMovement == null)
        {
            return;
        }

        controller.enemyMovement.enabled= true;
    }


}
