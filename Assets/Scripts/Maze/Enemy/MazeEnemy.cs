using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeEnemy : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    public GameObject EXP;
    Animator ani;
    private bool beingHandled = false;

    bool DentroExplo = false;
    private void Start()
    {
        EXP.SetActive(false);
        ani = GetComponent<Animator>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            if (beingHandled == false)
            {
                StartCoroutine(HandleIt());
            }


        }
        if (DentroExplo == true && EXP.activeSelf)
        {
            Debug.Log("Muerto");
        }
    }
    private IEnumerator HandleIt()
    {
        beingHandled = true;
        // process pre-yield

        yield return new WaitForSeconds(5.0f);

        Debug.Log("espera");
        EXP.SetActive(true);
        Debug.Log("destruido");
        Destroy(this.gameObject, 1);

        //ani.SetBool("IsExplode", true);

        // process post-yield
        beingHandled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
            DentroExplo = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
            DentroExplo = false;

        }
    }
}
