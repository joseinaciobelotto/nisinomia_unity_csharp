using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class detectMonster : MonoBehaviour
{

    public monsterFighter inColiMonster;
       public monsterColision monsterPositionHere;

    public List<GameObject> colidingObject  = new List<GameObject>();

    public float shortestDistance;

    public int[] objIndex = new int[100];

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
        if (collision.gameObject.tag == "monster")
        {
            colidingObject.Add(collision.gameObject);
            inColiMonster.inColiClient = true;
           

        }


        
        
    }



    void OnTriggerStay2D(Collider2D collision)
    {
        int aux = 0;
        
        foreach (GameObject obj in colidingObject)
        {

            float hipObj = (Mathf.Sqrt((Mathf.Pow((obj.transform.position.x), 2) + Mathf.Pow((obj.transform.position.y), 2))));

            if (hipObj < shortestDistance)
            {
                shortestDistance = hipObj;


                aux++;
                inColiMonster.monsterPositionHere = obj.GetComponent<monsterColision>().transform;
            }

            
           

        }
        if (aux == 0)
        {
            shortestDistance = 1000;
        }
    }

     void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="monster")
        {



            colidingObject.Remove(collision.gameObject);

            if (colidingObject.Count <= 0)
            {
                inColiMonster.inColiClient = false;
                inColiMonster.monsterPositionHere = null;

            }



        }
    }
}
