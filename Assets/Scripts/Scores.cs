using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    [SerializeField] GameObject scoreList;

    // Start is called before the first frame update
    void Start()
    {
        scoreList.GetComponent<TextMeshProUGUI>().text = "";

        int[] bestSocres = {0, 0, 0, 0, 0, 0, 0, 0 };
        string[] playernames = new string[8];

        for (int i = 0; i < GameManager.Instance.scoreColection.Scores.Count; i++)
        {
            string player = GameManager.Instance.scoreColection.PlayerName[i];
            int score = GameManager.Instance.scoreColection.Scores[i];

            bool ishigher = false;
            for (int a = 0; a < bestSocres.Length && !ishigher; a++)
            {
                if (bestSocres[a] < score)
                {
                    ishigher = true;
                    for(int b = bestSocres.Length - 1; b > a; b--)
                    {
                        bestSocres[b] = bestSocres[b - 1];
                        playernames[b] = playernames[b - 1];
                    }
                    bestSocres[a] = score;
                    playernames[a] = player;
                }
            }            
        }

        for (int i = 0; i < bestSocres.Length; i++)
        {
            scoreList.GetComponent<TextMeshProUGUI>().text += $"{i+1}) Player: {playernames[i]} Score: {bestSocres[i]}\n";   
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
