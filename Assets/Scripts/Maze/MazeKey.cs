using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MazeKey : MonoBehaviour
{

    void OnTriggerEnter2D()
    {
        transform.parent.SendMessage("OnKeyFound", SendMessageOptions.DontRequireReceiver);
        GameObject.Destroy(gameObject);
    }

}