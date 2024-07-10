using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedColision : MonoBehaviour
{


    public bool colisionBed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            colisionBed = true;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colisionBed = false;


        }
    }
}
