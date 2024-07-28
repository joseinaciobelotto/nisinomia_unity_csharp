using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallColision : MonoBehaviour
{

    public bool onCollisionWalls;
    public float time = 0;
    public float repeatTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if (onCollisionWalls == true)
        {
            time += Time.deltaTime;
        }
        else 
        {
            time = 0; 
        };

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            onCollisionWalls = true;
        }
           
    }
 

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            onCollisionWalls = false; 
        }
    }
}
