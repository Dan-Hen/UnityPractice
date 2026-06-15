using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.WSA;

public class GameFlow : MonoBehaviour
{
    
  
    /* General Flow
    ----- For Debug ----- 
    [x] spwan random
    [x] affect them an id
    [ ] select id
    [ ] display id

    ----- start of the game ----- 

    [] enter trigger box
    turn on input e for my game and switch off any unwanted behavior from other games 
    press "e" to play
    sweep player available in the world 
    choose randomly a player 
    create role hunter and hunted
    notify the hunter
    notify the hunted
    start timer

    ---- Win / Found ----
    notify both player
    add time + bonus to scoreboard 

    ---- lose / not found ----
    notify both player
    add time + malus to scoreboard


    ----- at any time -----

    press "f" to give up

    
    */
    
    public GameObject MainMenu;
    public GameObject InGameHUD;
    private bool playerInZone = false;
    public GameObject HuntedCharaPrefab;
    public Material choosenColor;
    private GameObject[] huntedPlayerList ;
    public int AmountOfPlayer = 10;
    private bool playerFound;
    public float timer;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI HuntedIdText;
    private GameObject huntedPlayer;
    private bool IsPlaying = false;
    



    void Awake()
    {   
        InGameHUD.SetActive(false);
        MainMenu.SetActive(false);
        //debug generate a list of hunted player
        huntedPlayerList = new GameObject[10];
        
        for (var i = 0; i <AmountOfPlayer; i++)
        {
             huntedPlayerList[i] = Instantiate(HuntedCharaPrefab, new Vector3(Random.Range(-30.0f, 30.0f), 0,Random.Range(-30.0f, 30.0f)), Quaternion.identity);
             huntedPlayerList[i].name = "Hunted_" + i; 
        };
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !IsPlaying )
        {
            MainMenu.SetActive(true);
            playerInZone = true;

            MainMenu.SetActive(true);
        }
    }

       void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            CloseMenu();
        }
    }

    public void CloseMenu()
    {
        MainMenu.SetActive(false);
        playerInZone = false;
    }

    void GameLaunch()
    {
        InGameHUD.SetActive(true);
        IsPlaying = true ;
        //choose the hunted player
        int RandomPlayer = Random.Range(0, AmountOfPlayer);
        huntedPlayer = huntedPlayerList[RandomPlayer];

        //debug to see the guys easily 
        huntedPlayer.transform.position += new Vector3(0, 1f, 0);
        HuntedIdText.text = "Player: "+ huntedPlayer.name;

        Hunted huntedScript = huntedPlayer.GetComponent<Hunted>();
        huntedScript.gameFlow = GetComponent<GameFlow>();
        huntedScript.Init(this);

        // start the timer
        StartCoroutine(DoTimer());   
    
    }

    public void Win()
    {   
        InGameHUD.SetActive(false);
        playerFound = true;
        Debug.Log("you win");
        Debug.Log(timer);
    }

    void GameOver()
    {
       IsPlaying = false;
       Debug.Log("game over, you loose");
    }

     IEnumerator DoTimer()
    {
        while (timer > 0 && playerFound != true )
        {
            // Update the UI
            timerText.text = string.Format("{0:00}:{1:00}", 
                Mathf.FloorToInt(timer / 60), 
                Mathf.FloorToInt(timer % 60));

            // Subtract the time passed since the last frame
            timer -= Time.deltaTime;

            // Wait until the next frame
            yield return null; 
        }
        
        timer = 0;
        timerText.text = "00:00";
        Debug.Log("Time's Up!");

        GameOver();
    }

        void Update()
    {
        if (playerInZone && !IsPlaying && Keyboard.current.eKey.wasPressedThisFrame)
        {
            MainMenu.SetActive(false);
            GameLaunch();
        }
    }
}
