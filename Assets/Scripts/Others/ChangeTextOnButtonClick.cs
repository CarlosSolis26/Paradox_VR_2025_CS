using TMPro;
using UnityEngine;

namespace Others
{
    public class ChangeTextOnButtonClick : MonoBehaviour
    {
        public TextMeshProUGUI txtText;

        public void ChangeText()
        {
            txtText.text = "Este es el nuevo texto";
        }
    }
}
