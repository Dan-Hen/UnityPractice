using UnityEngine;
using Unity.Netcode;
using UnityEngine.UIElements;
using Unity.Netcode.Transports.UTP;

public class MultiUI : MonoBehaviour
{

    UIDocument uiDocument;
    Button disconnectButton;
    TextField ipTextField;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
    }
    private void Start()
    {
        Button hostButton = uiDocument.rootVisualElement.Q<Button>("HostButton");
        Button serverButton = uiDocument.rootVisualElement.Q<Button>("ServerButton");
        Button clientButton = uiDocument.rootVisualElement.Q<Button>("ClientButton");
        disconnectButton = uiDocument.rootVisualElement.Q<Button>("DisconnectButton");
        ipTextField = uiDocument.rootVisualElement.Q<TextField>("IPAdressTextField");

        hostButton.clicked += OnHostClicked;
        serverButton.clicked += OnServerClicked;
        clientButton.clicked += OnClientClicked;
        disconnectButton.clicked += OnDisconectClicked;
        
        ipTextField.focusable = true ;
    }

    void OnHostClicked()
    {
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ipTextField.value, 7777);
        NetworkManager.Singleton.StartHost();
        ipTextField.focusable = true ;
        
    }

    void OnServerClicked()
    {
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ipTextField.value, 7777);
        NetworkManager.Singleton.StartServer();
        ipTextField.focusable = true ;
    }

    void OnClientClicked()
    {
        
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ipTextField.value, 7777);
        NetworkManager.Singleton.StartClient();
        ipTextField.focusable = true ;
    }

    void OnDisconectClicked()
    {
        ipTextField.focusable = false;
        NetworkManager.Singleton.Shutdown();
           
    }
}
