using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public string firstLevel;
    public Text Name;

public void StartGame() {
        //MainManager.playerName = Name.text.ToString();
        SceneManager.LoadScene(firstLevel);
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quitting...");
    }
}
