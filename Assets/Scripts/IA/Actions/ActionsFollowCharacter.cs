using UnityEngine;

[CreateAssetMenu(menuName = "IA/Acciones/Seguir personaje")]
public class ActionsFollowCharacter : IAAction
{
    public override void Execute(IAController controller)
    {
        FollowCharacter(controller);
    }

    private void FollowCharacter (IAController controller)
    {
        if (controller.characerReference == null)
        {
            return;
        }

        Vector3 directionToCharacter = controller.characerReference.position - controller.transform.position;
        Vector3 direction = directionToCharacter.normalized;
        float distance = directionToCharacter.magnitude;
        if (distance >= 1.30f)
        {
            controller.transform.Translate(direction * controller.VelocityMovement * Time.deltaTime);
        }
    }
}
