using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PineappleLifeManager : BaseManager<PineappleLifeManager>
{
    public int currentAskAmount { get; private set; }
    public int maxAskAmount { get; private set; } = 4;
    // Start is called before the first frame update

    //add saved data later
    protected override void Start()
    {
        base.Start();
        currentAskAmount =0;
    }


    public void IncreaseAskAmount()
    {
        currentAskAmount += 1;
    }

    public void ResetAmount()
    {
        currentAskAmount = 0;
    }

}
