using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public bool isNight = false;
    public float dayTime;
    public float dayTimeRepeat;
    public int dayCount;
    public sleep sleepCountHere;

    // Start is called before the first frame update
    void Start()
    {

        sleepCountHere = FindAnyObjectByType<sleep>();
    }

    // Update is called once per frame
    void Update()
    {
        sleepCountFunc();
    }

    void sleepCountFunc()
    {
        if (sleepCountHere.sleepCount > dayCount && dayTime > dayTimeRepeat)
        {
            dayCount++;
            dayTime = 0;
            isNight = true;

        }
        else
        {
            dayTime += Time.deltaTime;
            isNight = false;
        }
    }

  

}
