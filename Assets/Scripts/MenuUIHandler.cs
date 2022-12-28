using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject inputField;

    public void TextChange()
    {
        GameManager.Instance.PlayerName = inputField.GetComponent<TMP_InputField>().text;
    }

    public void StartNew()
    {
        if (GameManager.Instance.PlayerName == "" || GameManager.Instance.PlayerName == null)
        {
            GameManager.Instance.PlayerName = "Default";
        }
        SceneManager.LoadScene(1);
    }

    public void Scores()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
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
