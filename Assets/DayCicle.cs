using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public float dayTime;
    public int dayCount;

    public bool isNight = false;
    public float nightTime;

    public sleep sleepCountHere;

    public nightLayer nightLayerHere;

    public float becomeNightTime = 10;
    public float endNighTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        nightLayerHere = FindAnyObjectByType<nightLayer>();
        sleepCountHere = FindAnyObjectByType<sleep>();
    }

    // Update is called once per frame
    void Update()
    {
        SleepCountFunc();
    }

    void SleepCountFunc()
    {

        dayTime += Time.deltaTime;

        if (isNight ==true )
        {
            if (dayTime > endNighTime)
            {
                isNight = false; 
                dayCount++;
                dayTime = 0;
            }

        }
        else if(isNight== false)
        {
  
            if (dayTime > becomeNightTime)
            {
                isNight= true;        
            }
        }
       




    }

  

}
