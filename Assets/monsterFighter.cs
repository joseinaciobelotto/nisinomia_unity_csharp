using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterFighter : MonoBehaviour
{

    public Rigidbody2D haste;
    public float speed;
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
    public float repeatTime;

    public float range;


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


                modfX = Random.Range(-1, 2);
                modfY = Random.Range(-1, 2);
                time = repeatTime;
            }
            time -= Time.deltaTime;
        }

        move1 = new Vector3(modfX * speed, modfY * speed, 0);
        return move1;
    }


    // Start is called before the first frame update
    void Start()
    {
        haste = GetComponent<Rigidbody2D>();

       

        move1 = new Vector3(0, 0, 0);

        move2 = new Vector3(0, 0, 0);





    }







    // Update is called once per frame
    void FixedUpdate()
    {

        haste.transform.position += testeX() * Time.deltaTime;






    }



}
