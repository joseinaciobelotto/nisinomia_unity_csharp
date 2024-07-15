using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinDrop : MonoBehaviour
{
    Rigidbody2D rig;
    public int oneTime = 0;
    Vector3 leaveJump;
    Vector3 coinMoveVec;
    float randomSideY;
    float randomSideX;
    public float power = 1;
    public float power2 = 0;
    public float power3 = 0;
    public float time = 0;
    public float setTime;

    public float speed;

    public float modfX;
    public float modfY;

    public bool inColiClientCoinRange;
    public bool inColiClientCoinRangeInPlayer;
   
    public Movement playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        randomSideX = Random.Range(-2, 2) + 1f;
        randomSideY = Random.Range(-2, 2) + 1f;
        leaveJump = new Vector3(randomSideX / 10, randomSideY / 10, 0);
      
        playerPosition = FindAnyObjectByType<Movement>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (time > setTime || power <= 0)
        {
            power = 0;
        }
        else
        {

            if (power <= 1 && power > 0)
            {
                power -= power3;
            }
            else
            {
                power -= power2;
                power2 = Mathf.Pow(2, 2 / power2);

            }
            time += Time.deltaTime;
            rig.transform.position += leaveJump * power;

        }

        coinMove();



    }

    void coinMove()
    {

        if (inColiClientCoinRange == true)
        {


            if (playerPosition.transform.position.x < transform.position.x)
            {
                modfX = -1f;
            }
            else if (playerPosition.transform.position.x > transform.position.x)
            {
                modfX = 1f;
            }
            if (playerPosition.transform.position.y < transform.position.y)
            {
                modfY = -1f;
            }
            else if (playerPosition.transform.position.y > transform.position.y)
            {
                modfY = 1f;
            }

            coinMoveVec = new Vector3(modfX * speed, modfY * speed, 0);
            rig.transform.position += coinMoveVec * speed;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coinRange")
        {
            inColiClientCoinRange = false;
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coinRange")
        {
            inColiClientCoinRange = true;
        }

      


    }



}
