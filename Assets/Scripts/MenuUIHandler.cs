using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour {

    public GameObject BestScoreText;

    public void Start() {
        string playerName = GameManager.Instance.scoreColection.PlayerName[GameManager.Instance.scoreColection.bestScoreIndex];
        int bestScore = GameManager.Instance.scoreColection.Scores[GameManager.Instance.scoreColection.bestScoreIndex];
        BestScoreText.GetComponent<TextMeshProUGUI>().text = $"Best Score : {playerName} : {bestScore}";
    }



    [SerializeField] private GameObject inputField;

    public void TextChange() {
        GameManager.Instance.PlayerName = inputField.GetComponent<TMP_InputField>().text;
    }

    public void StartNew() {
        if (GameManager.Instance.PlayerName == "" || GameManager.Instance.PlayerName == null) {
            GameManager.Instance.PlayerName = "Default";
        }
        SceneManager.LoadScene(1);
    }

    public void Scores() {
        SceneManager.LoadScene(2);
    }

    public void Settings() {
        SceneManager.LoadScene(3);
    }

    public void Quit() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void Back() {
        SceneManager.LoadScene(0);
    }

}
