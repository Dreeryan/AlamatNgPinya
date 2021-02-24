using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision_Chase : Decision
{
    public override bool Decide(StateController controller)
    {
        //check if character is it
        bool isIt = controller.tagCharacterComponent.IsTagged;
        return isIt;
    }
}
