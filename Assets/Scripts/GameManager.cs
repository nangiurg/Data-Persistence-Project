using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string PlayerName;

    [System.Serializable]
    public class ScoreColection
    {
        public List<int> Scores = new List<int>();
        public List<string> PlayerName = new List<string>();
        public int bestScoreIndex;
    }

    public ScoreColection scoreColection = new ScoreColection();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScoreFile();
    }

    private void LoadScoreFile()
    {
        string path = Application.persistentDataPath + "/ScoreFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            scoreColection = JsonUtility.FromJson<ScoreColection>(json);
        }
    }

    private void SaveScoreFile()
    {
        string json = JsonUtility.ToJson(scoreColection);
        File.WriteAllText(Application.persistentDataPath + "/ScoreFile.json", json);
    }

    public void ScoreCalculator(int Score)
    {
        bool isBestScore = true;
        for(int i = 0; i < scoreColection.Scores.Count; i++)
        {
            if(Score < scoreColection.Scores[i])
            {
                isBestScore = false;
            }
        }

        if (isBestScore)
        {
            scoreColection.bestScoreIndex = scoreColection.Scores.Count;
        }

        scoreColection.PlayerName.Add(PlayerName);
        scoreColection.Scores.Add(Score);

        SaveScoreFile();
    }
}
