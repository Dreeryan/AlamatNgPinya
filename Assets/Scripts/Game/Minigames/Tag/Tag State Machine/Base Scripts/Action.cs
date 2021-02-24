using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public virtual void Act(StateController controller)
    {
      //  if (GameManager.Instance.IsPaused) return;
    }
}
