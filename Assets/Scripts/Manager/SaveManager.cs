using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayerSave
{
    public PlayerSave()
    {
        savedMotivation = MotivationManager.Instance.MaxMotivation;
    }
    public int savedMotivation;
}

public class SaveManager : BaseManager<SaveManager>
{
    private static PlayerSave playerData;
    public static PlayerSave PlayerData => playerData;

    public List<GameObject> managers = new List<GameObject>();

    protected override void Start()
    {
        base.Start();

        if (DoesFileExist("player"))
        {
            playerData = LoadData<PlayerSave>("player");

            managers.ForEach(obj =>
            {
                IManager manager = obj.GetComponent<IManager>();

                if (manager != null)
                    manager.LoadData(playerData);
            });
        }
        else
        {
            playerData = new PlayerSave();
            SavePlayer();
        }
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

    #region Shortcut Save functions
    public static void SavePlayer()
    {
        SaveData(playerData, "player");
    }
    #endregion
}
