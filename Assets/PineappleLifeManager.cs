using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PineappleLifeManager : BaseManager<PineappleLifeManager>,ISavedData
{
    public int currentAskAmount { get; private set; }
    public int maxAskAmount { get; private set; } = 4;
    // Start is called before the first frame update

    //add saved data later
    protected override void Start()
    {
        base.Start();
        InitializeSavedData();
    }


    public void IncreaseAskAmount()
    {
        SaveData();
        currentAskAmount += 1;
    }

    public void ResetAmount()
    {
        SaveData();
        currentAskAmount = 0;
    }

    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
    }

    public void InitializeSavedData()
    {
        if (!SaveManager.DoesFileExist("PlayerData"))
        {
            currentAskAmount = 0;
            return;
        }

        PlayerSave playerData = SaveManager.LoadData<PlayerSave>("PlayerData");
        currentAskAmount = playerData.savedPineappleLife;
    }

    public void SaveData()
    {
        SaveManager.Instance.playerSavedData.savedPineappleLife = this.currentAskAmount;
    }

}
