using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class factoryItens : MonoBehaviour
{
  

    public coinColector coinColectorHere;
    
    public bool colisionplayer;
    public Movement MovementHere;
    public string[] itensNames = new string[100];
    public int itemAmountNeed;
    public TextMesh feedback;
    public TextMesh questText;

    public GameObject prefabMix;

    public Vector3 diretionFac;

    // Start is called before the first frame update
    void Start()
    {
        diretionFac = new Vector3(0,-1,0);
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
        int aux = 0;
        int auxAux = 0;
        int[] auxlist = new int[10];
        //bool questComplet = false;
      //  int numOfMix = 0;
        int whereIsFirst = 0;
        string chosed = "";
        foreach (var resorces in coinColectorHere.resourceColectedList)
        {
            whereIsFirst++;
            if (resorces.name != null)
            {

                if (resorces.amount >= itemAmountNeed)
                {
                    if (resorces.name == "Cenoura" || resorces.name == "Tomate" && aux == 0)
                    {

                        auxlist[auxAux++] = aux;
                        aux++;
                        if (resorces.name == "Cenoura")
                        {
                            chosed = "Cenoura";
                        }
                        else if (resorces.name == "Tomate")
                        {
                            chosed = "Tomate";
                        }
                    }
                    else if (aux == 1)
                    {
                        
                        if (chosed == "Tomate" || resorces.name == "Cenoura" )
                        {
                            auxlist[auxAux++] = aux;
                            aux++;
                            coinColectorHere.resourceColectedList[auxlist[0]].amount -= 1;
                            coinColectorHere.resourceColectedList[auxlist[1]].amount -= 1;
                            GameObject materiaDrop = Instantiate(prefabMix, transform.position + diretionFac, Quaternion.identity);
                            return;
                        }
                        else if(chosed == "Cenoura" || resorces.name == "Tomate")
                        {
                            auxlist[auxAux++] = aux;
                            aux++;
                            coinColectorHere.resourceColectedList[auxlist[0]].amount -= 1;
                            coinColectorHere.resourceColectedList[auxlist[1]].amount -= 1;
                            GameObject materiaDrop = Instantiate(prefabMix, transform.position + diretionFac, Quaternion.identity);
                            return;


                        }
                    }

                }
                else if (resorces.name == itensNames[0] || resorces.name == itensNames[1] && resorces.amount <= itemAmountNeed)
                {
                    feedback.text = "Faltam itens ainda!";
                }
                else
                {
                    feedback.text = "";
                }



            }

        }

        /*
      while (numOfMix > 0)
      {
          GameObject materiaDrop = Instantiate(prefabMix,diretionFac , Quaternion.identity);
      }
     for (int aux3 = 0; aux3 < 10 && questComplet != true; aux3++)
       {
           int auxComplete = 0;

           if (auxlist[aux3] > 0)
           {
               auxComplete++;
               if (auxComplete >= 2)
               {

               }
           }
       }*/
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


