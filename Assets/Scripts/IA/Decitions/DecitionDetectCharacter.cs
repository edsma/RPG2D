using UnityEngine;

[CreateAssetMenu(menuName ="IA/Decitions/Detectar personajes")]
public class DecitionDetectCharacter : IADecision
{
    public override bool Choose(IAController controller)
    {
        return DetectCharacer(controller);
    }

    public bool DetectCharacer(IAController controller)
    {
        Collider2D characterDetect = Physics2D.OverlapCircle(controller.transform.position,
            controller.RangeDetection,controller.CharacterLayerMask);
        if (characterDetect != null)
        {
            controller.characerReference = characterDetect.transform;
            return true;
        }

        return false;
    }

}
