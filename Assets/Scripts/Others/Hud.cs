using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace Others
{
    public class Hud : MonoBehaviour
    {
        public GameObject uiElement;  // El objeto UI que deseas activar
        private InputDevice leftController;
        private bool isUIActive = false;
        private bool isButtonPressedLastFrame = false;  // Para verificar el estado anterior del botón

        void Start()
        {
            // Inicializa la lista de dispositivos
            List<InputDevice> devices = new List<InputDevice>();
        
            // Obtiene los dispositivos del controlador izquierdo
            InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, devices);
        
            // Asume que el primer dispositivo encontrado es el controlador izquierdo
            if (devices.Count > 0)
            {
                leftController = devices[0];
            }
        }

        void Update()
        {
            // Verifica si el controlador izquierdo está conectado
            if (leftController.isValid)
            {
                // Verifica si el botón X está presionado en el controlador izquierdo
                bool xButtonPressed;
                if (leftController.TryGetFeatureValue(CommonUsages.primaryButton, out xButtonPressed))
                {
                    // Solo activamos/desactivamos la UI cuando el botón pasa de no presionado a presionado
                    if (xButtonPressed && !isButtonPressedLastFrame)
                    {
                        isUIActive = !isUIActive;
                        uiElement.SetActive(isUIActive);  // Activar o desactivar la UI
                    }
                
                    // Actualiza el estado anterior del botón
                    isButtonPressedLastFrame = xButtonPressed;
                }
            }
        }
    }
}
