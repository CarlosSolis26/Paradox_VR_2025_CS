using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.XR;

namespace Others
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject uiPanel; // El panel de la UI que deseas mostrar/ocultar
        private InputDevice rightController;
        private bool isUIActive = false;
        private bool isButtonPressedLastFrame = false;  // Para verificar el estado anterior del botón

        void Start()
        {
            // Inicializa la lista de dispositivos
            List<InputDevice> devices = new List<InputDevice>();
        
            // Obtiene los dispositivos del controlador izquierdo
            InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
        
            // Asume que el primer dispositivo encontrado es el controlador izquierdo
            if (devices.Count > 0)
            {
                rightController = devices[0];
            }
        }

        void Update()
        {
            // Verifica si el controlador izquierdo está conectado
            if (rightController.isValid)
            {
                // Verifica si el botón A está presionado en el controlador izquierdo
                bool aButtonPressed;
                if (rightController.TryGetFeatureValue(CommonUsages.primaryButton, out aButtonPressed))
                {
                    // Solo activamos/desactivamos la UI cuando el botón pasa de no presionado a presionado
                    if (aButtonPressed && !isButtonPressedLastFrame)
                    {
                        isUIActive = !isUIActive;
                        //uiPanel.SetActive(isUIActive);  // Activar o desactivar la UI
                        GameManager.Instance.PauseGame();
                    }
                
                    // Actualiza el estado anterior del botón
                    isButtonPressedLastFrame = aButtonPressed;
                }
            }
        }
    }
}
