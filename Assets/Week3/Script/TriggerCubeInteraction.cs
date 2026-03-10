using Unity.Netcode;
using UnityEngine;

public class TriggerCubeInteraction : NetworkBehaviour
{
    NetworkVariable<Color> cubeColor = new NetworkVariable<Color>(new Color(255, 0, 0));
    Material cubeMaterial; 
    private void Awake()
    {
        cubeMaterial = GetComponent<Renderer>().material;
    }

    public override void OnNetworkSpawn() 
    {
        cubeColor.OnValueChanged += OnColorChange;
        if (IsServer)
        {
            cubeColor.Value = Color.red;
        }
        cubeMaterial.color = cubeColor.Value;
    }

    void OnColorChange(Color oldColor, Color newColor)
    {
        cubeMaterial.color = newColor;
    }

    void OggerEnter(Collider other)
    {
        if (IsServer) cubeColor.Value = other.GetComponent<Renderer>().material.color;      
    }
}