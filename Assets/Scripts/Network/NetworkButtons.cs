using Unity.Netcode;
using UnityEngine;

public class NetworkButtons : MonoBehaviour
{
    public void StartServer() => NetworkManager.Singleton.StartServer();

    public void StartHost() => NetworkManager.Singleton.StartHost();

    public void StartClient() => NetworkManager.Singleton.StartClient();
}
