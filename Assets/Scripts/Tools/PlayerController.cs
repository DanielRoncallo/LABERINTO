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
 

    // Start is called before the first frame update
    void Start()
    {
        //nivel = 1;
        NivelElem.text = "Nivel: " + nivel.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        NivelElem.text = "Nivel: " + nivel.ToString();
        TimeCount += Time.deltaTime;
        TimeElem.text = "Tiempo: " + Mathf.Round(TimeCount).ToString();
    }
    public void NextLevel()
    {
        nivel += 1;
    }
    public void SceneLevel()
    {
        if (nivel == 1)
        {
            SceneManager.LoadScene("Game");
        }
        if (nivel == 2)
        {
            SceneManager.LoadScene("Game2");
        }
        if (nivel == 3)
        {
            SceneManager.LoadScene("Game3");
        }
        if (nivel == 4)
        {
            SceneManager.LoadScene("Game4");
        }

    }
}
