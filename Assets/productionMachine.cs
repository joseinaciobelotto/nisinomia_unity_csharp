using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class productionFactory2 : MonoBehaviour
{



    public float workersSalaryCoins;

    public global_coins globalCoinsHere;

    public DayCycle isNightHere;



  

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


    }

    public float BuyingFromFactory(int merchandiseId)
    {
        if (globalCoinsHere.merchandisesListSector2[merchandiseId].amount > 0)
        {
            globalCoinsHere.merchandisesListSector2[merchandiseId].amount--;
            workersSalaryCoins += globalCoinsHere.merchandisesListSector2[merchandiseId].price;
            return globalCoinsHere.merchandisesListSector2[merchandiseId].price;
        }
        else
        {
            return -1;
        }


    }
   
}
