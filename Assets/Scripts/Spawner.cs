using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Spawner : MonoBehaviour
{

    public GameObject objectToSpawn; // El prefab del objeto que deseas instanciar
    public Transform spawnPoint;     // El punto donde aparecerá el objeto
    private XRBaseInteractable interactable;

    private void Start()
    {
        // Obtener el componente interactable del botón
        interactable = GetComponent<XRBaseInteractable>();

        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnButtonPressed);
        }
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (objectToSpawn != null && spawnPoint != null)
        {
            // Instanciar el objeto en la posición y rotación del punto de aparición
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Object spawned!");
        }
    }

    private void OnDestroy()
    {
        // Desenlazar el evento para evitar errores cuando se destruya el objeto
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnButtonPressed);
        }
    }

}
