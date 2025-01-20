using TMPro;
using UnityEngine;

public class ChangeTextOnButtonClick : MonoBehaviour
{
    public TextMeshProUGUI txtText;

    public void ChangeText()
    {
        txtText.text = "Este es el nuevo texto";
    }
}
