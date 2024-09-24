using System.Threading.Tasks;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class RelayManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI joinCodeText;
    [SerializeField] private TMP_InputField joinCodeInputField;

    private void Start()
    {
        UnityMultiplayerServicesInit();
    }

    private async void UnityMultiplayerServicesInit()
    {
        // add the await keyword to avoid game freezing
        // because it takes some time to receive the response
        // Initialize Unity Services
        await UnityServices.InitializeAsync();

        // Anonymous authentication
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void StartRelayHost()
    {
        string joinCode = await StartRelayHostAsync();
        joinCodeText.text = joinCode;
    }

    // Async functions because it takes some time for them to be executed
    // Make the async function return a string with Task<string>
    public async Task<string> StartRelayHostAsync(int maxConnections = 3)
    {
        // Create allocation in Relay setting the max number of players
        var allocation = await RelayService.Instance.CreateAllocationAsync(maxConnections);

        // Set Relay Server data
        // Create new allocation and set the data transport protocol to dtls
        NetworkManager.Singleton.GetComponent<UnityTransport>()
            .SetRelayServerData(new RelayServerData(allocation, "dtls"));

        // Get join code if Host started successfully or null if not.
        var joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

        var relayHostStarted = NetworkManager.Singleton.StartHost();

        return relayHostStarted ? joinCode : null;
    }

    // Check if the client connection is successful
    // public async Task<bool> StartRelayClientAsync(string joinCode)
    // {
    //     
    // }
}