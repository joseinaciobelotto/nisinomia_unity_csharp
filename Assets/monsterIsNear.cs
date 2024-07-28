using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterIsNear : MonoBehaviour
{

    public BoxCollider2D collidingMonster;

    public bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        collidingMonster = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {
            isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {
            isColliding = false;
        }

    }
}
