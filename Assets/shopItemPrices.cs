using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class shopItemPrices3 : MonoBehaviour
{
   
 

    public DayCycle isNightHere;

    public float shopMoney;

    public global_coins globalCoinsHere;
   

   

    // Start is called before the first frame update
    void Start()
    {
        isNightHere = FindAnyObjectByType<DayCycle>();
        globalCoinsHere = FindAnyObjectByType<global_coins>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ItensPriceInfaltion()
    {
        

        
    }

    void GettingItensSource()
    {
        
        if (isNightHere.isNight == true)
        {
       
             foreach(global_coins.ResourceTypes itemOfList in globalCoinsHere.productsListSector3)
            {
                itemOfList.price = 2;

            }
        }

    }

   public float BuyingFromShop(int itemId)
    {
        if (globalCoinsHere.productsListSector3.Count > 0 )
        {
            
       
        if (globalCoinsHere.productsListSector3[itemId].amount > 0)
        {
            globalCoinsHere.productsListSector3[itemId].amount--;
            shopMoney += globalCoinsHere.productsListSector3[itemId].price;
            return globalCoinsHere.productsListSector3[itemId].price;
        }
        }
        return -1;
        

       
    }
}
