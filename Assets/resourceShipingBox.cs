using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class resourceShipingBox1 : MonoBehaviour
{


    public float huntersSalaryCoins;

    public coinCollectorMonsterFighter coinColectorHere;
    public showResourceShipBox showResourceShipBoxHere;
    public global_coins globalCoinsHere;


    public bool inColiClient;

    public int auxNumResources;





    // Start is called before the first frame update
    void Start()
    {
        showResourceShipBoxHere = FindAnyObjectByType<showResourceShipBox>();
        globalCoinsHere = FindAnyObjectByType<global_coins>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

   

    public void TranferListTranferList()
    {
        auxNumResources = 0;

        foreach (var collectedResource in  coinColectorHere.resourceColectedList)
        { 
          

            foreach (var resource in globalCoinsHere.resourcesListSector1)
            {
                if (collectedResource.name == resource.name)
                {
                    if (collectedResource.amount > 0)
                    {
                        resource.amount += collectedResource.amount;
                        coinColectorHere.resourceColectedList.Remove(collectedResource);
                        return;
                    }
                    return;

                }
                else
                {
                    auxNumResources ++;
                 
                }
            }


            if (globalCoinsHere.resourcesListSector1.Count == 0)
            {
                auxNumResources++;
            }
           
            if (auxNumResources >= globalCoinsHere.resourcesListSector1.Count)
            {

         
                global_coins.ResourceTypes item = new global_coins.ResourceTypes(collectedResource.name, collectedResource.price, collectedResource.amount);
                globalCoinsHere.resourcesListSector1.Add(item);
                coinColectorHere.resourceColectedList.Remove(collectedResource);
           
            }
                    
                    
                
            }

        showResourceShipBoxHere.FormatingText();

    }

   }


