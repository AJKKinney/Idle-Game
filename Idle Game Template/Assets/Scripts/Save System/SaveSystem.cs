using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static SaveData currentSave = null;
    private static string saveDataPath = Application.persistentDataPath + "/SaveData.save";

    #region Getters & Setters

    public static SaveData CurrentSave 
    { 
        get 
        {
            if (currentSave == null)
            {
                currentSave = LoadGame();
            }

            return currentSave;
        } 
        set => currentSave = value; 
    }

    #endregion

    public static void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = saveDataPath;
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = currentSave;

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static SaveData LoadGame()
    {
        SaveData loadedSaveData = null;

        string path = saveDataPath;

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            loadedSaveData = (SaveData) formatter.Deserialize(stream);

            stream.Close();
        }
        else
        {
            Debug.Log("No save data exists at " + saveDataPath + ". Creating a new save file.");
            loadedSaveData = new SaveData();
        }

        return loadedSaveData;
    }
}
