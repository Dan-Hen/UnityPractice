using Unity.VisualScripting;
using UnityEngine;

public class Hunted : MonoBehaviour
{
    public GameFlow gameFlow;

    //private GameFlow gameFlowScript;

    public void Init(GameFlow flow)
    {
        gameFlow = flow;
    }

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) 
    {
        if (gameFlow != null)
        {
            gameFlow.Win();  
        }
    }
}
