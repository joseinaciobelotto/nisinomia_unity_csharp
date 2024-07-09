using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global_coins : MonoBehaviour
{
    public float globalInflation;
    public float debt;
    public float debtFees;



    public sleep sleepCountHere;
    public DayCycle dayTime;

    
     
   
 





    // Start is called before the first frame update
    void Start()
    {
        dayTime = FindAnyObjectByType<DayCycle>();
    }

    // Update is called once per frame
    void Update()
    {

        if (dayTime.isNight == true)
        {
            isNightCalc();
        }
    

       

    }

    void isNightCalc()
    {

        

            globalInflation += Random.Range(1, 4);
            debt -= (debt * debtFees) / 100;

    }

    
    
}
