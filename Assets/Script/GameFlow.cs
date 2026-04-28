using UnityEngine;

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
    
    public GameObject HuntedCharaPrefab;
    public Material choosenColor;
    private GameObject[] huntedPlayerList ;
    public int AmountOfPlayer = 10;
    private bool playerFound;
    private float timer ;



    void Awake()
    {
        huntedPlayerList = new GameObject[10];
        
        for (var i = 0; i <AmountOfPlayer; i++)
        {
             huntedPlayerList[i] = Instantiate(HuntedCharaPrefab, new Vector3(Random.Range(-30.0f, 30.0f), 0,Random.Range(-30.0f, 30.0f)), Quaternion.identity);
             huntedPlayerList[i].name = "Hunted_" + i; 
        };
        
    }

    void Start()
    {
        GameLaunch();
    }

    void GameLaunch()
    {
        int RandomPlayer = Random.Range(0, AmountOfPlayer);

        //debug to see the guys easily 
        huntedPlayerList[RandomPlayer].transform.position += new Vector3(0, 2f, 0);
        Debug.Log("find player" + huntedPlayerList[RandomPlayer].name );

        // start the timer
        TimerStart();

        // if player is found == true {}
        if (playerFound == true)
        {
            TimerStop();
        }


    }

    void TimerStart()
    {
        Debug.Log("Timer Start");

        

        if (timer <= 0) {
            GameOver();
            
        }
       
    }

    void TimerStop()
    {
        
    }

    void GameOver()
    {
       Debug.Log("game over, you loose");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
