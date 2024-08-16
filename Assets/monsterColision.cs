using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterColision : MonoBehaviour
{

    public Rigidbody2D haste;
    public float speed;
    public Transform monsterPosition;

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


    public int speedMax;
    public int speedMin;
    public float speedTotal;
    public int speedMult;

    public float repeatTimeMax;
    public float repeatTimeMin;

    public float rangeOfTransformTest;
    public float timeOfTransformTest;
    public wallColision wallColisionHere;


    public float lifeNow;
    public float lifeMax;
    public float damage;
    public float armor;
    public float lifeRegen;
    public float atackSpeed;




    Vector3 testeX()
    {

        if (inColiClient == true)  
        {


            TargetPosition(playerPosition.transform);
        }
    
     

        move1 = new Vector3(modfX * speed, modfY * speed, 0);
        move1 = Vector3.Normalize(move1);
        return move1;
    }


    // Start is called before the first frame update
    void Start()
    {
        haste = GetComponent<Rigidbody2D>();

        playerPosition = FindAnyObjectByType<Movement>();

        move1 = new Vector3(0, 0, 0);

        move2 = new Vector3(0, 0, 0);

        wallColisionHere = GetComponentInChildren<wallColision>();
            


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monsterRange")
        {
            inColiClient = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monsterRange")
        {
            inColiClient = false;
        }
    }

    void TargetPosition(Transform targetTransform)
    {
        if (targetTransform.transform.position.x  < transform.position.x )
        {
            modfX = -1f;
        }
        else if (targetTransform.transform.position.x  > transform.position.x )
        {
            modfX = 1f;
        }
        if (targetTransform.transform.position.y  < transform.position.y )
        {
            modfY = -1f;
        }
        else if (targetTransform.transform.position.y > transform.position.y )
        {
            modfY = 1f;
        }

    }

    private void Update()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
         
        speedTotal = Random.Range(speedMin, speedMax) * speedMult;
        haste.transform.position += testeX() * speedTotal * Time.deltaTime;

        TestingTranform(haste);



    }

    void TestingTranform(Rigidbody2D transformHere)
    {
        Vector3 fighterPosition = new Vector3(transformHere.transform.position.x, transformHere.transform.position.y, 0);



        if (time <= 0)
        {

            modfX = 10 / Random.Range(-100f, 100f);
            modfY = 10 / Random.Range(-100f, 100f);
            time = Random.Range(repeatTimeMin, repeatTimeMax);


        }

        if (haste.transform.position.x < fighterPosition.x + rangeOfTransformTest && haste.transform.position.x > fighterPosition.x - rangeOfTransformTest &&
          haste.transform.position.y < fighterPosition.y + rangeOfTransformTest && haste.transform.position.x > fighterPosition.y - rangeOfTransformTest && wallColisionHere.time > timeOfTransformTest)
        {


            modfX *= -Random.Range(-1f, 2f);
            modfY *= -Random.Range(-1f, 2f);
            wallColisionHere.time = 0;

          
        }

        time -= Time.deltaTime;
    }


}
