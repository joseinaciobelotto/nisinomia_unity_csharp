using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionWithClient : MonoBehaviour
{
    public coinCollectorMonsterFighter coinColectorHere;
    public resourceShipingBox1 shipingBox1Here;
    public GameObject shipingScreen;
    public bool colisionplayer;
    public Movement MovementHere;

    public bool trueCollisionplayer;

    // Start is called before the first frame update
    void Start()
    {
        shipingBox1Here = GetComponent<resourceShipingBox1>();
       
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E) && colisionplayer == true)
        {
            shipingScreen.SetActive(false);

        }
        else if (Input.GetKeyDown(KeyCode.E) && colisionplayer == true)
        {
            shipingScreen.SetActive(true);
        }*/
        if (Input.GetKeyDown(KeyCode.E) && colisionplayer == true)
        {
            shipingBox1Here.TranferListTranferListPlayer();
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monsterFighter")
        {

            coinColectorHere = collision.gameObject.GetComponent<coinCollectorMonsterFighter>();

            Debug.Log("!ggg");
            shipingBox1Here.TranferListTranferList();
        }
        if (collision.gameObject.tag == "Player")
        {
            
                shipingScreen.SetActive(true);
                colisionplayer = true;

            MovementHere = collision.gameObject.GetComponent<Movement>();

           
        }
    }
   
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            shipingScreen.SetActive(false);
            colisionplayer =false;
        }
    }

}
