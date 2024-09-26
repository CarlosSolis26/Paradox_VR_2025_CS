using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text txtFin;
    public GameObject goFin;

    public void MostrarPantallaFinal(string mensaje)
    {
        goFin.SetActive(true);
        txtFin.text = mensaje;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Destroy(other.gameObject);
            MostrarPantallaFinal("HAS GANADO");
        }
    }
}
