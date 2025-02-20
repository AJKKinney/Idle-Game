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

    public static bool LoadGame(int fileNumber, out SaveData loadedSave)
    {
        bool hasSaveInSlot = false;
        SaveData loadedSaveData = null;

        saveDataPath = Application.persistentDataPath + "/SaveDataFile" + fileNumber.ToString() + ".save";

        if (File.Exists(saveDataPath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(saveDataPath, FileMode.Open);

            loadedSaveData = (SaveData) formatter.Deserialize(stream);

            stream.Close();
            hasSaveInSlot = true;
        }
        else
        {
            Debug.Log("No save data exists at " + saveDataPath);
            loadedSaveData = new SaveData();
        }

        loadedSave = loadedSaveData;
        return hasSaveInSlot;
    }
}
