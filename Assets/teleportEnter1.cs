using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportEnter1 : MonoBehaviour
{


  public Transform tp;

    public Vector3 tpVec;
    public Movement move;
    public bool isTeleporting;

    // Start is called before the first frame update
    void Start()
    {

        tpVec = new Vector3(tp.transform.position.x, tp.transform.position.y, tp.transform.position.z);
        move = FindObjectOfType<Movement>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTeleporting == true)
        {
            move.teleportTo(tpVec);
            
        };
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
                isTeleporting = true;

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                isTeleporting = false;

           
        }
    }

}
     
    


