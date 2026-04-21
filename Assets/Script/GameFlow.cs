using System.Security.Principal;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    /* General Flow

    ----- start of the game ----- 

    enter trigger box
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
    void Start()
    {
        for (var i = 0; i <10; i++)
        {
            Instantiate(HuntedCharaPrefab, new Vector3(i*2.0f, 0,0), Quaternion.identity);
        }
        //spawn cubes
        //spawn a class
        //sweep cubes
    }

    void GameLaunch()
    {
        //choose a random cube
        //display ui with hunted character poster
        //start Timer()

    }

    void Timer()
    {
        //time start
        //loop 
        //time elapsed
            // game over
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
