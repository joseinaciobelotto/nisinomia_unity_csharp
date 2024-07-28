using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atackHitCollider : MonoBehaviour
{

    public BoxCollider2D colliderHitAtack;
    public SpriteRenderer spritHitBox;


    // Start is called before the first frame update
    void Start()
    {
        colliderHitAtack = GetComponent<BoxCollider2D>();
        spritHitBox = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {

            Destroy(collision.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {

         
        }
    }
}
