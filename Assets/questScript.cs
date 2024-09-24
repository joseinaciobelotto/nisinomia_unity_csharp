using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class questScript : MonoBehaviour
{

    public coinColector coinColectorHere;
    public GameObject questScreeen;
    public GameObject gate;
    public bool colisionplayer;
    public Movement MovementHere;
    public string[] itensNames = new string[100];
    public int itemAmountNeed;
    public TextMesh feedback;
    public TextMesh questText;

    // Start is called before the first frame update
    void Start()
    {
        
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

        foreach (var resorces in coinColectorHere.resourceColectedList)
        {

            if (resorces.name != null)
            {
                
                if (resorces.amount >= itemAmountNeed )
                {
                    if (resorces.name == itensNames[0] || resorces.name == itensNames[1])
                    {
                        
                        auxlist[auxAux++] = aux;
                        aux++;
                        if (aux >= 2)
                        {
                            coinColectorHere.resourceColectedList.RemoveAt(auxlist[auxAux]);
                            coinColectorHere.resourceColectedList.RemoveAt(auxlist[auxAux--]);
                            questText.text = "Quest Concluída"!;
                            questScreeen.SetActive(false);
                            gate.SetActive(false); 
                        }

                    }

                }
                else if (resorces.name == itensNames[0] || resorces.name == itensNames[1] && resorces.amount <= itemAmountNeed)
                {
                    feedback.text = "Faltam itens ainda!";
                }
                    
                   
               
            }
            
        }

       /* for (int aux3 = 0; aux3 < 10 && questComplet != true; aux3++)
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

            questScreeen.SetActive(true);
        colisionplayer = true;

        coinColectorHere = collision.gameObject.GetComponent<coinColector>();


    }
}

public void OnTriggerExit2D(Collider2D collision)
{
    if (collision.gameObject.tag == "Player")
    {

            questScreeen.SetActive(false);
            colisionplayer = false;
    }
}

}
