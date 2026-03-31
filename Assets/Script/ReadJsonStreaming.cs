using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class ReadJsonStreaming : MonoBehaviour
{
    string path;
    string jsonFile = "streaming.json";

    private void Start()
    {
        // write direct path to the file
        path = Path.Combine(Application.streamingAssetsPath, jsonFile);
        print(path);
        //StreamingJSON();
        StartCoroutine(WebRequestJSON());
    }

    IEnumerator WebRequestJSON()
    {   
        //error because of naming between highscore and HighScore I guess
        path = "https://www.googleapis.com/drive/v3/files/1P75YYjsaIPSR3ATPPQbRJQtjdrjz9eGq?alt=media&key=AIzaSyC6V3UlbtrMo06h0qf1dM7adYT-dSlU5Zk";

        UnityWebRequest www = UnityWebRequest.Get(path);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            print("error" + www.error);
        }
        else
        {
            string jsonString = File.ReadAllText(path);

            TestStreams highscoresInJSON = JsonUtility.FromJson<TestStreams>(jsonString);
            foreach (TestStream highScore in highscoresInJSON.highscores)
            {
                print("Player Name :" + highScore.playerName + ", Player Score: " + highScore.playerScore);
            }
        }
    }

    private void StreamingJSON()
    {
        string jsonString = File.ReadAllText(path);

        HighScores highscoresInJSON = JsonUtility.FromJson<HighScores>(jsonString);
        foreach (HighScore highscore in highscoresInJSON.highscores)
        {
            print("Player Name :" + highscore.playerName + ", Player Score: " + highscore.playerScore);
        }
    }
}

[System.Serializable]
public struct TestStream
{
    public string playerName;
    public int playerScore;
}

[System.Serializable]
public struct TestStreams
{
    public TestStream[] highscores;

}

