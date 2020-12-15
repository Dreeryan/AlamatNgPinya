using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveManager : BaseManager<SaveManager>
{
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
        if(!File.Exists(fileName))
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

    private static string MakePath(string fileName, string format = ".sav")
    {
        return Application.persistentDataPath + "/" + fileName + format;
    }
}
