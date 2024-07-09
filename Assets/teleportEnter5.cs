using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportEnter5 : MonoBehaviour
{

    public bool colisionWithPlayer;
    public TeleportExit5 tp;
    public Vector3 transferVar;

    // Start is called before the first frame update
    void Start()
    {
        tp = FindAnyObjectByType<TeleportExit5>();
    }

    // Update is called once per frame
    void Update()
    {
        transferVar = tp.tpXYZB;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            colisionWithPlayer = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            colisionWithPlayer = false;
        }
    }
}
