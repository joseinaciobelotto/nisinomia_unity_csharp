using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knowlege : MonoBehaviour
{

    public coinColector coinColectorHere;

    public bool colisionplayer;

    public bool adquired = false;

    public Movement movementHere;


    public float coinAmountNeed = 5;

    public float damageToGive;
     

    public GameObject know;
    public GameObject message;

    public player_coins playerCoinsHere;



    // Start is called before the first frame update
    void Start()
    {
        coinColectorHere = FindAnyObjectByType<coinColector>();
        playerCoinsHere = FindAnyObjectByType < player_coins >();
        movementHere = FindAnyObjectByType < Movement >();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && colisionplayer == true)
        {

            chechkItensQuest();


        }
    }

    public void chechkItensQuest()
    {
       
        if (playerCoinsHere.plaeyrCoinsAmount >= coinAmountNeed && adquired == false)
        {
            playerCoinsHere.plaeyrCoinsAmount -=coinAmountNeed;
            movementHere.damage += damageToGive;
            message.SetActive(false);
            know.SetActive(true);
            adquired = true;
        }
                   
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {


            colisionplayer = true;

   

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            colisionplayer = false;
        }
    }
}
