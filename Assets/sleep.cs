using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleep : MonoBehaviour
{
    public bedColision inColiHere;
    public DayCycle isNightHere;

    public bool inColiClient;
    public int sleepCount;



    // Start is called before the first frame update
    void Start()
    {

        inColiHere = FindAnyObjectByType<bedColision>();
        isNightHere = FindAnyObjectByType<DayCycle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inColiHere.colisionBed == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {



                if (isNightHere.isDay == false)
                {
                    isNightHere.isDay = true;
                }
                else if (isNightHere.isDay == true)
                {
                    isNightHere.isDay = false;


                }
            }

        }
    }
}

