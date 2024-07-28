using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingActions : MonoBehaviour
{

    public float clientMoneyBag;
    private Colision clientColi;
    public bool inShopColi;
    public DayCycle dayCycle;
    public bool boughtToday;
    public shopItemPrices3 itenBought;

    public global_coins globalCoinsHere;

  
    // Start is called before the first frame update
    void Start()
    {
        clientColi = GetComponent<Colision>();
        dayCycle = FindAnyObjectByType<DayCycle>();
        itenBought = FindAnyObjectByType<shopItemPrices3>();
        globalCoinsHere = FindAnyObjectByType<global_coins>();


    }

    // Update is called once per frame
    void Update()
    {
        PerDayActions();
    }

    void DayBuying()
    {
        if (inShopColi == true && clientMoneyBag >= 20)
        {
            int i;
            i = Random.Range(0, 1 );

            if (itenBought.BuyingFromShop(i) > 0)
            {
                clientMoneyBag -= itenBought.BuyingFromShop(i);

                boughtToday = true;
            }
            else
            {
                boughtToday = false;
            }

           
        }
        
    }
    void PerDayActions()
    {
        if (dayCycle.isNight == false)
        {
            if (boughtToday == false)
            {
                DayBuying();
            }
       
        }
        else if (dayCycle.isNight == true)
        {
            boughtToday = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inShopColi = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inShopColi = false;
    }

}
