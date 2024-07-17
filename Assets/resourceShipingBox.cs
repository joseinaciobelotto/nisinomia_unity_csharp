using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class resourceShipingBox1 : MonoBehaviour
{


    public float huntersSalaryCoins;

    public coinCollectorMonsterFighter coinColectorHere;
    public showResourceShipBox showResourceShipBoxHere;


    public bool inColiClient;

    public int auxNumResources;

    public List<resourceTypes> resorceList;

    [System.Serializable]
    public class resourceTypes
    {
        public string name;
        public float price;
        public float quantityLeft;

        public resourceTypes(string name, float price, int amout)
        {
            this.name = name;
            this.price = price;
            this.quantityLeft = amout;
        }


    }



    // Start is called before the first frame update
    void Start()
    {
        showResourceShipBoxHere = FindAnyObjectByType<showResourceShipBox>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

   

    public void tranferList()
    { 
       

        for (int aux = 0; aux < coinColectorHere.resourceColectedList.Count; aux++)
        {
          

            foreach (resourceTypes resource in resorceList)
            {
                if (coinColectorHere.resourceColectedList[aux].resourceName == resource.name)
                {
                    if (coinColectorHere.resourceColectedList[aux].quantityLeft > 0)
                    {
                        resource.quantityLeft += coinColectorHere.resourceColectedList[aux].quantityLeft;
                        coinColectorHere.resourceColectedList.Remove(coinColectorHere.resourceColectedList[aux]);
                        return;
                    }
                    return;

                }
                else
                {
                    auxNumResources ++;
                }
            }

            if (resorceList.Count == 0 || auxNumResources > resorceList.Count)
            {
                resourceTypes item = new resourceTypes(coinColectorHere.resourceColectedList[aux].resourceName, coinColectorHere.resourceColectedList[aux].price, coinColectorHere.resourceColectedList[aux].quantityLeft);
                resorceList.Add(item);
                coinColectorHere.resourceColectedList.Remove(coinColectorHere.resourceColectedList[aux]);
                return;
            }
                    
                    
                
            }

        showResourceShipBoxHere.formatingText();

    }

   }


