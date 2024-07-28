using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static coinColector;
using static resourceShipingBox1;
using static shopItemPrices3;


public class showResource : MonoBehaviour
{

    public TextMesh a;
    public coinColector coinColectorHere;




    public List<resourcesToShow> resourcesToShowList;


    [System.Serializable]
    public class resourcesToShow
    {

        public string name;
        public float price;
        public int quantityLeft;

        public resourcesToShow(string name, float price, int amout)
        {
            this.name = name;
            this.price = price;
            this.quantityLeft = amout;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        coinColectorHere = FindAnyObjectByType<coinColector>();
        a.text = "";

    }



    // Update is called once per frame
    void Update()
    {
      //  showItem();
    }


    /*
    void showItem()
    {
        for (int aux = 0; aux < coinColectorHere.resourceColectedList.Count; aux++)
        {

            foreach (resourcesToShow resource in resourcesToShowList)
            {
                if (coinColectorHere.resourceColectedList[aux].resourceName == resource.name)
                {
                    if (coinColectorHere.resourceColectedList[aux].quantityLeft > 0)
                    {
                        resource.quantityLeft = coinColectorHere.resourceColectedList[aux].quantityLeft;

                        formatingText(resource);
                    }

                }
                else
                {
                    resourcesToShow item = new resourcesToShow(coinColectorHere.resourceColectedList[aux].resourceName, coinColectorHere.resourceColectedList[aux].price, coinColectorHere.resourceColectedList[aux].quantityLeft);
                    resourcesToShowList.Add(item);
                    coinColectorHere.resourceColectedList.Remove(coinColectorHere.resourceColectedList[aux]);
                    formatingText(item);
                }
              
            }


        }
    }
    */

    public void formatingText()
    {
        a.text = "";
        for (int aux = 0; aux < coinColectorHere.resourceColectedList.Count; aux++)
        {

            a.text += coinColectorHere.resourceColectedList[aux].name + " " + coinColectorHere.resourceColectedList[aux].amount + "\n";
        }

    }



}