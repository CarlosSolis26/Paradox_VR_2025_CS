using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instancia;
    public TMP_Text txtFin;
    public GameObject goFin;

    public void MostrarPantallaFinal(string mensaje)
    {
        goFin.SetActive(true);
        txtFin.text = mensaje;
    }

    public void OcultarPantallaFinal()
    {
        goFin.SetActive(false);
        //txtFin.text = mensaje;
    }
}
