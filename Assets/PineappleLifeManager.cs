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
        currentAskAmount += 1;
        SaveData();
    }

    public void ResetAmount()
    {
        currentAskAmount = 0;
        SaveData();
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
