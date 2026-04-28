using UnityEngine;

public class Hunted : MonoBehaviour
{
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(other);
    }
}
