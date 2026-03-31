using Unity.VisualScripting;
using UnityEngine;

public class ReadJson : MonoBehaviour
{
    [SerializeField]
    private TextAsset jsonText; 

    private void Start()
    {
        HighScores highscoresInJSON = JsonUtility.FromJson<HighScores>(jsonText.text);
        //print(highscoresInJSON.highscores[1].playerScore);
        foreach(HighScore highscore in highscoresInJSON.highscores)
        {
            print("Player Name :" + highscore.playerName + ", Player Score: " + highscore.playerScore); 
        }
    }
}

    [System.Serializable]
    public struct HighScore
    {
        public string playerName;
        public int playerScore;
    }

    [System.Serializable]
    public struct HighScores
    {
       public HighScore[] highscores;

    }

