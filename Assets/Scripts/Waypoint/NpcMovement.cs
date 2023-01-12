using Assets.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Common.Constants;

public class NpcMovement : WaypointMovement
{
    private readonly int walkDown = Animator.StringToHash(Constants.ParamsAnimations.walkingDown);

    protected override void RotateCharacter()
    {
        if (direction != MovementDirection.Vertical)
        {
            return;
        }

        if (pointForMove.y > lastPosition.y)
        {
            _animator.SetBool(walkDown, true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            _animator.SetBool(walkDown, false);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    protected override void RotateVerticalCharacter()
    {
        if (direction != MovementDirection.Vertical)
        {
            return;
        }

        if (pointForMove.y > lastPosition.y)
        {
            _animator.SetBool(walkDown, true);
        }
        else
        {
            _animator.SetBool(walkDown, false);
        }
    }


}
