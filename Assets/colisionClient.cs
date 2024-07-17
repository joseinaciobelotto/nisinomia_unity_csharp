using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionWithClient : MonoBehaviour
{
    public coinCollectorMonsterFighter coinColectorHere;
    public resourceShipingBox1 shipingBox1Here;
    public GameObject shipingScreen;
    public bool colisionplayer;

    // Start is called before the first frame update
    void Start()
    {
        shipingBox1Here = GetComponent<resourceShipingBox1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monsterFighter")
        {

            coinColectorHere = collision.gameObject.GetComponent<coinCollectorMonsterFighter>();

           shipingBox1Here.tranferList();
        }
        if (collision.gameObject.tag == "Player")
        {
            
                shipingScreen.SetActive(true);
                colisionplayer = true;
            
          
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
