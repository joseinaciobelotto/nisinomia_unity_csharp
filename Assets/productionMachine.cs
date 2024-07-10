using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class productionMachine : MonoBehaviour
{

    public List<Items> itemsList;

    public DayCycle isNightHere;

    public float shopMoney;



    [System.Serializable]
    public class Items
    {

        public string name;
        public float price;
        public int quantityLeft;

    }

    // Start is called before the first frame update
    void Start()
    {
        isNightHere = FindAnyObjectByType<DayCycle>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void itensPriceInfaltion()
    {



    }

    void gettingItensSource()
    {

        if (isNightHere.isNight == true)
        {

            foreach (Items itemOfList in itemsList)
            {
                itemOfList.price = 2;

            }
        }

    }

    public float buyingFromShop(int itemId)
    {
        if (itemsList[itemId].quantityLeft > 0)
        {
            itemsList[itemId].quantityLeft--;
            shopMoney += itemsList[itemId].price;
            return itemsList[itemId].price;
        }
        else
        {
            return -1;
        }


    }
   
}
