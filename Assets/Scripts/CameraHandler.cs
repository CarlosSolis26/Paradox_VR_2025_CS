using Unity.Netcode;

public class CameraHandler : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if(!IsOwner) gameObject.SetActive(false);
    }
}
