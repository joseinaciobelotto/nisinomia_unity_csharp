using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selling : MonoBehaviour
{

    public coinColector coinColectorHere;

    public bool colisionplayer;
    public Movement MovementHere;
    public string[] itensNames = new string[100];
    public int itemAmountNeed;
    public TextMesh feedback;
    public TextMesh questText;

    public GameObject coin;

    public Vector3 diretionFac;

    // Start is called before the first frame update
    void Start()
    {
        diretionFac = new Vector3(0, -1, 0);
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
       // int aux = 0;
//int auxAux = 0;
        int[] auxlist = new int[10];
        //bool questComplet = false;
       // int numOfMix = 0;
        int whereIsFirst = 0;
       // string chosed = "";
        foreach (var resorces in coinColectorHere.resourceColectedList)
        {
           
            if (resorces.name != null)
            {

                if (resorces.amount >= 1)
                {
                    if (resorces.name == "Salada" )
                    {

                       
                            coinColectorHere.resourceColectedList[whereIsFirst].amount -= 1;
                            
                            GameObject materiaDrop = Instantiate(coin, transform.position + diretionFac, Quaternion.identity);
                        
                    }

                }
                else if (resorces.name == itensNames[0] || resorces.name == itensNames[1] && resorces.amount <= itemAmountNeed)
                {
                    feedback.text = "Quero saladas";
                }
                else
                {
                    feedback.text = "";
                }



            }
            whereIsFirst++;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {


            colisionplayer = true;

            coinColectorHere = collision.gameObject.GetComponent<coinColector>();


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
