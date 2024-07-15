using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterFighter : MonoBehaviour
{

    public Rigidbody2D haste;

    public int speedMax;
    public int speedMin;
    public float speedTotal;
    public int speedMult;

    public Transform monsterPositionHere;

    public clientsFinishPoint finishPointRespective;
    public Movement playerPosition;

    public Vector3 move3;
    public Vector3 move2;
    public Vector3 move1;

    public bool inColiClient;

    public float a;
    public float c2;
    public float b;
    public float c;

    public float modfY;
    public float modfX;
    public float time;

    public float repeatTimeMax;
    public float repeatTimeMin;

    public float range;

    public DayCycle isDayHere;


    Vector3 testeX()
    {

        if (inColiClient == true)
        {


            if (monsterPositionHere.transform.position.x < transform.position.x)
            {
                modfX = -1f;
            }
            else if (monsterPositionHere.transform.position.x > transform.position.x)
            {
                modfX = 1f;
            }
            if (monsterPositionHere.transform.position.y < transform.position.y)
            {
                modfY = -1f;
            }
            else if (monsterPositionHere.transform.position.y > transform.position.y)
            {
                modfY = 1f;
            }
        }
        else
        {
            if (time <= 0)
            {



                modfX = 10 / Random.Range(-100f, 100f);

                modfY = 10 / Random.Range(-100f, 100f);
                time = Random.Range(repeatTimeMin, repeatTimeMax);
            }
            time -= Time.deltaTime;
        }

        move1 = new Vector3(modfX, modfY, 0);
        move1 = Vector3.Normalize(move1);
        return move1;
    }


    // Start is called before the first frame update
    void Start()
    {
        haste = GetComponent<Rigidbody2D>();

        isDayHere = FindAnyObjectByType<DayCycle>();

        move1 = new Vector3(0, 0, 0);

        move2 = new Vector3(0, 0, 0);





    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isDayHere.isNight == true)
        {
            
        }
        speedTotal = Random.Range(speedMin, speedMax) * speedMult;
        haste.transform.position += testeX() * speedTotal * Time.deltaTime;


    }


    void sellResoursces()
    {

        


    }


}



