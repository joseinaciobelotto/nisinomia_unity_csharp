using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atackCollider : MonoBehaviour
{

    public BoxCollider2D colliderAtack;
    public bool atackHit;

    // Start is called before the first frame update
    void Start()
    {
        colliderAtack = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {

            atackHit = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {

            atackHit = false;
        }
    }

}
