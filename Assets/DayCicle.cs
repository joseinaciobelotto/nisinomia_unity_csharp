using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public bool isDay = true;
    public float dayTime;
    public float dayTimeMax;
    public int dayCount;

    public bool isNight = false;
    public float nightTime;
    public float nightTimeMax;
    public int nightCount;

    public int teste;

    public sleep sleepCountHere;

    public nightLayer nightLayerHere;

    // Start is called before the first frame update
    void Start()
    {
        nightLayerHere = FindAnyObjectByType<nightLayer>();
        sleepCountHere = FindAnyObjectByType<sleep>();
    }

    // Update is called once per frame
    void Update()
    {
        sleepCountFunc();
    }

    void sleepCountFunc()
    {
        

        if (isNight ==true && isDay == false)
        {
           
                nightTime+= Time.deltaTime;
         
            if (nightTime > nightTimeMax)
            {
                isNight = false;
                dayTime = 0;
            }
            /* nightCount++;     
             dayTime = 0;
             isNight = true;
             isDay = false;
             nightTime += Time.deltaTime;
             nightLayer.enabled = true;
             */


        }
        else if(isNight == false && isDay == true)
        {
           
                dayTime += Time.deltaTime;
          
            if (dayTime > dayTimeMax)
            {
                nightTime = 0;
                isNight = true;
            }

           /*
            dayCount++;
            isNight = false;
            isDay = true;
          
            nightTime = 0;
           
         
            nightLayer.enabled = false;
           */
        }
       




    }

  

}
