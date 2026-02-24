using UnityEngine;
using Unity.Netcode;
using UnityEngine.UIElements;

public class MultiUI : MonoBehaviour
{

    UIDocument uiDocument;

    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
    }
    void Start()
    {
        Button hostButton = uiDocument.rootVisualElement.Q<Button>("HostButton");
        Button serverButton = uiDocument.rootVisualElement.Q<Button>("ServerButton");
        Button clientButton = uiDocument.rootVisualElement.Q<Button>("ClientButton");

        hostButton.clicked += OnHostClicked;
        serverButton.clicked += OnServerClicked;
        clientButton.clicked += OnClientClicked;
    }

    void OnHostClicked()
    {
        NetworkManager.Singleton.StartHost();
        
    }

    void OnServerClicked()
    {
        NetworkManager.Singleton.StartServer();
    }

    void OnClientClicked()
    {
        NetworkManager.Singleton.StartClient();
    }
}
