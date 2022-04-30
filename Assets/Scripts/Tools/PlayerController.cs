using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public int nivel;
    public Text NivelElem;
    static public float TimeCount;
    public Text TimeElem;
     static private int nivFinal;

    // Start is called before the first frame update
    void Start()
    {
        //nivel = 1;
        if (nivel == 0)
        {
            TimeCount = 0;
        }
        NivelElem.text = "Nivel: " + nivel.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        if (nivel != 5 && nivel != 6)
        {
            nivFinal = nivel;
            Debug.Log(nivFinal + "nivFinal");
            NivelElem.text = "Nivel: " + nivel.ToString();
            TimeCount += Time.deltaTime;
            TimeElem.text = "Tiempo: " + Mathf.Round(TimeCount).ToString();
        }
        if (nivel == 5)
        {
            NivelElem.text = "Niveles \nsuperados";
            TimeElem.text = "Tiempo: " + Mathf.Round(TimeCount).ToString();
        }
        if (nivel == 6)
        {
            Debug.Log(nivFinal + "nivFinal");
            NivelElem.text = "Nivel: " + nivFinal.ToString();
            TimeElem.text = "Tiempo: " + Mathf.Round(TimeCount).ToString();
        }



    }
    public void NextLevel()
    {

        nivel += 1;
    }


    public void SceneLevel()
    {
        Debug.Log(nivFinal + "nivFinal");

        if (nivel == 1)
        {
            nivFinal = 1;
            SceneManager.LoadScene("Game");
        }
        if (nivel == 2)
        {
            nivFinal = 2;
            SceneManager.LoadScene("Game2");
        }
        if (nivel == 3)
        {
            nivFinal = 3;
            SceneManager.LoadScene("Game3");
        }
        if (nivel == 4)
        {
            nivFinal = 4;
            SceneManager.LoadScene("Game4");
        }
        if (nivel == 5)
        {
            SceneManager.LoadScene("Win");
        }


    }
}
