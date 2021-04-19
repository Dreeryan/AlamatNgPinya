using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class PlayerSave
{
    public int savedMotivation;
    public int savedPineappleLife;
    public int savedList;
}

public class SaveManager : BaseManager<SaveManager>
{
    public PlayerSave playerSavedData;

    private void Awake()
    {
        if (!SaveManager.DoesFileExist("PlayerData"))
        {
            playerSavedData = new PlayerSave();
            return;
        }
        this.playerSavedData = SaveManager.LoadData<PlayerSave>("PlayerData");
    }
    protected override void Start()
    {
        base.Start();
    }
    /*
     * Call Example
     * int oldHighScore;
     * SaveManager.SaveData(oldHighScore, "highScore");
     */
    public static void SaveData<T>(T dataToSave, string fileName)
    {
        string json = JsonUtility.ToJson(dataToSave);

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);

        BinaryWriter outFile = new BinaryWriter(
            File.Open
            (MakePath(fileName)
            , FileMode.Create));

        outFile.Write(bytes);
        outFile.Close();
    }

    /*
     * Call Example
     * int oldHighScore = SaveManager.LoadFile<int>("highScore");
    */
    public static T LoadData<T>(string fileName)
    {
        if (!DoesFileExist(fileName))
        {
            Debug.LogErrorFormat("{0} cannot be loaded as it does NOT exist!", fileName);
            return default;
        }

        byte[] bytes = null;

        using (BinaryReader br = new BinaryReader
            (File.Open
            (MakePath(fileName)
            , FileMode.Open)))
        {
            long length = br.BaseStream.Length;
            bytes = br.ReadBytes((int)length);
            br.Close();
        }

        string json = System.Text.Encoding.UTF8.GetString(bytes);

        T loadedFile = default;

        loadedFile = JsonUtility.FromJson<T>(json);

        return loadedFile;
    }
	
	 public static void DeleteFile(string fileName)
    {
		if(!DoesFileExist(fileName)) return;
		
        try
        {
            Debug.LogError("Deleting " + fileName);
            File.Delete(MakePath(fileName));
        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
    }
	
    public static bool DoesFileExist(string fileName)
    {
        return File.Exists(MakePath(fileName));
    }

    private static string MakePath(string fileName, string format = ".sav")
    {
        return Application.persistentDataPath + "/" + fileName + format;
    }

    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();

        SaveManager.SaveData<PlayerSave>(playerSavedData, "PlayerData");
    }
}
