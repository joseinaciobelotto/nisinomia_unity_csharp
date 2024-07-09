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
    public shopItemPrices itenBought;


    // Start is called before the first frame update
    void Start()
    {
        clientColi = GetComponent<Colision>();
        dayCycle = FindAnyObjectByType<DayCycle>();
        itenBought = FindAnyObjectByType<shopItemPrices>();



    }

    // Update is called once per frame
    void Update()
    {
        perDayActions();
    }

    void dayBuying()
    {
        if (inShopColi == true && clientMoneyBag >= 20)
        {
            int i;
            i = Random.Range(0, itenBought.itemsList.Count );

            if (itenBought.buyingFromShop(i) > 0)
            {
                clientMoneyBag -= itenBought.buyingFromShop(i);

                boughtToday = true;
            }
            else
            {
                boughtToday = false;
            }

           
        }
        
    }
    void perDayActions()
    {
        if (dayCycle.isNight == false)
        {
            if (boughtToday == false)
            {
                dayBuying();
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
