using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IADecision : ScriptableObject
{
    public abstract bool Choose(IAController controller);

}
