using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPine : MonoBehaviour
{

    
    public BoxCollider2D colid2;
    public player_coins coinsHere;
    public clientDestroy destroyEnemyScript;
  

    // Start is called before the first frame update
    void Start()
    {



        //BoxCollider2D colid2 = gameObject.AddComponent<BoxCollider2D>();
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {


            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
