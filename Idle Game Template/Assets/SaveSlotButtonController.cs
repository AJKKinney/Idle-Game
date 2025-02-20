using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveSlotButtonController : MonoBehaviour
{
    [SerializeField] private int saveSlotNumber;

    private Button button;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        button = GetComponent<Button>();
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        UpdateSaveSlotDisplay();

        button.onClick.AddListener(SelectSaveSlot);
    }

    private void UpdateSaveSlotDisplay()
    {
        if(SaveSystem.LoadGame(saveSlotNumber, out SaveData saveSlotData) == false)
        {
            textMesh.text = "Save File " + saveSlotNumber.ToString() + ": Empty";
        }
        else
        {
            textMesh.text = "Save File " + saveSlotNumber.ToString() + ": Full";
            //Fill in details with the output save slot data
        }
    }

    private void SelectSaveSlot()
    {
        SaveSystem.LoadGame(saveSlotNumber, out SaveData saveSlotData);
        SaveSystem.CurrentSave = saveSlotData;
        //Start Game
        SceneManager.LoadScene("Game Scene");
    }
}
