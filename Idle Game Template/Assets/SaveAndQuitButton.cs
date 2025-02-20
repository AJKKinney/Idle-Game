using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveAndQuitButton : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SaveAndQuit);
    }

    private void SaveAndQuit()
    {
        SaveSystem.SaveGame();
        SceneManager.LoadScene("Main Menu");
    }
}
