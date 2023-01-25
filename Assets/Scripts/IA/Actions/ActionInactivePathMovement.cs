using UnityEngine;

[CreateAssetMenu(menuName = "IA/Acciones/Inactivar camino movimiento")]
public class ActionInactivePathMovement : IAAction
{
    public override void Execute(IAController controller)
    {
        if (controller.enemyMovement == null)
        {
            return;
        }

        controller.enemyMovement.enabled = false;
    }
}
