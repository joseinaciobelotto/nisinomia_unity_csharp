using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectMonster : MonoBehaviour
{

    public monsterFighter inColiMonster;
       public monsterColision monsterPositionHere;        

    // Start is called before the first frame update
    void Start()
    {
        
    inColiMonster = FindAnyObjectByType<monsterFighter>();
     
    }

    // Update is called once per frame
    void Update()
    {
    
    

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="monster")
        {
            inColiMonster.inColiClient = true;
           inColiMonster.monsterPositionHere =  collision.gameObject.GetComponent<monsterColision>().transform;
        }
    }   
     void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="monster")
        {
            inColiMonster.inColiClient = false;
            inColiMonster.monsterPositionHere = null;
        }
    }
}
