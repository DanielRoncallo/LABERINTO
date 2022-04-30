using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Botones : MonoBehaviour
{
     public void InicioJuego()
    {
        SceneManager.LoadScene("Game");
    }


    public void InstruccionesJuego()
    {
        SceneManager.LoadScene("Instrucciones");
    }
    public void VolverInicio()
    {
        SceneManager.LoadScene("Inicio");
    }

}
