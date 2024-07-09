using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleep : MonoBehaviour
{
    public Colision inColiHere;
    public DayCycle isNightHere;
    public int sleepCount;
    // Start is called before the first frame update
    void Start()
    {

        inColiHere = FindAnyObjectByType<Colision>();
        isNightHere = FindAnyObjectByType<DayCycle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inColiHere.inColiBed1 == true)
        {
            if (Input.GetKeyDown(KeyCode.E) )
            {
                if (isNightHere.dayCount == sleepCount)
                {
                    sleepCount++;
                   
                }
               
            }
        }
    }
    }

