using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
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
    public float time2;

    public float distance;
    public float distance2;

    public float repeatTimeMax;
    public float repeatTimeMin;

    public float range;

    public DayCycle isDayHere;

    public float rangeOfTransformTest;
    public float timeOfTransformTest;
    public wallColision wallColisionHere;

    public GameObject shipingBoxPosition;
    public GameObject goingToMonsters;

    public float lifeNow;
    public float lifeMax;
    public float damage;
    public float armor;
    public float lifeRegen;
    public float atackSpeed;
    public float atackRange;
    public float timeToAtack;

    public atackCollider atackColliderHere;
    public atackHitCollider atackHitColliderHere;
    public monsterIsNear monsterIsNearHere;

    public Vector3 atackDirection;

    public GameObject aimObject;
    public GameObject waponObject;

    public bool positionAtibuited = false;

    public float timeCountAtack = 0;
    public float multiplyingZ = 1;
    Vector3 testeX()
    {
        if (isDayHere.isNight != true)
        {
            if (inColiClient == true)
            {
                if (monsterPositionHere != null)
                {
                    TargetPosition(monsterPositionHere, haste);
                    AtackMode();
                }

            }
            else
            {
                TargetPosition(goingToMonsters.transform, haste);
            }
        }
        else
        {
            TargetPosition(shipingBoxPosition.transform, haste);
        }






        move1 = new Vector3(modfX, modfY, 0);
        move1 = Vector3.Normalize(move1);
        return move1;
    }


    // Start is called before the first frame update
    void Start()
    {
        haste = GetComponent<Rigidbody2D>();

        wallColisionHere = FindAnyObjectByType<wallColision>();

        isDayHere = FindAnyObjectByType<DayCycle>();

        move1 = new Vector3(0, 0, 0);

        move2 = new Vector3(0, 0, 0);

        atackColliderHere = FindAnyObjectByType<atackCollider>();
        atackHitColliderHere = FindAnyObjectByType<atackHitCollider>();
        monsterIsNearHere = FindAnyObjectByType<monsterIsNear>();

      


    }

    // Update is called once per frame
    void FixedUpdate()
    {


        speedTotal = Random.Range(speedMin, speedMax) * speedMult;
        haste.transform.position += testeX() * speedTotal * Time.deltaTime;


        TestingTranform(haste);



    }


    void sellResoursces()
    {




    }

    void TargetPosition(Transform targetTransform, Rigidbody2D thisTransform)
    {

        Vector3 fighterPosition = new Vector3(targetTransform.transform.position.x, targetTransform.transform.position.y, 0);


        distance = Mathf.Pow((targetTransform.position.y - thisTransform.position.y), 2) + Mathf.Pow((targetTransform.position.x - thisTransform.position.x), 2);


        if (time2 <= 0)
        {

            if (targetTransform.transform.position.x < transform.position.x)
            {
                modfX = -1f;
            }
            else if (targetTransform.transform.position.x > transform.position.x)
            {
                modfX = 1f;
            }
            if (targetTransform.transform.position.y < transform.position.y)
            {
                modfY = -1f;
            }
            else if (targetTransform.transform.position.y > transform.position.y)
            {
                modfY = 1f;
            }
            time2 = Random.Range(repeatTimeMin, repeatTimeMax);
            distance2 = distance;

        }

        if (haste.transform.position.x < fighterPosition.x + rangeOfTransformTest && haste.transform.position.x > fighterPosition.x - rangeOfTransformTest &&
          haste.transform.position.y < fighterPosition.y + rangeOfTransformTest && haste.transform.position.x > fighterPosition.y - rangeOfTransformTest && wallColisionHere.time > timeOfTransformTest)
        {
           

            modfX *= -Random.Range(-1f, 2f);
            modfY *= -Random.Range(-1f, 2f);
          
            wallColisionHere.time = 0;
           


        }
        else if(distance > distance2)
        {
            modfX *= -Random.Range(-1f, 2f);
            modfY *= -Random.Range(-1f, 2f);
            
            wallColisionHere.time = 0;
            distance2 = Mathf.Pow((targetTransform.position.y - thisTransform.position.y), 2) + Mathf.Pow((targetTransform.position.x - thisTransform.position.x), 2);

        }


        time2 -= Time.deltaTime;



    }

    /*
    public int randomAxiX(float a)
    {
      
       
    }*/
/*
    public float randomAxiY()
    {
      

    }*/

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

    void AtackMode()
    {
        Vector3 y = new Vector3(0, 3, 0);
        Vector3 x = new Vector3(3, 0, 0);

        if (monsterIsNearHere.collidingMonster == true && timeToAtack < 0)
        {
            ColliderEnabled();

            atackDirection = new Vector3(monsterPositionHere.transform.position.x, monsterPositionHere.transform.position.y, 0);
            float tanValue = 0;

            Vector3 relativePosition = transform.InverseTransformPoint(aimObject.transform.position);
                
            Vector3 lastPosition = new Vector3(0f, 0f, 0f);
            if (atackColliderHere.transform.position.x < (transform.position.x + atackRange) && atackColliderHere.transform.position.x > (transform.position.x - atackRange) &&
            atackColliderHere.transform.position.y < (transform.position.y + atackRange) && atackColliderHere.transform.position.y > (transform.position.y - atackRange))
            {
                if (atackColliderHere.transform.position.x < monsterPositionHere.transform.position.x && atackColliderHere.transform.position.x < transform.position.x + atackRange - 3)
                {
                    atackColliderHere.transform.position += x * Time.deltaTime; ;

                }
                if (atackColliderHere.transform.position.y < monsterPositionHere.transform.position.y && atackColliderHere.transform.position.y < transform.position.y + atackRange - 3)
                {
                    atackColliderHere.transform.position += y * Time.deltaTime; ;
                }
                if (atackColliderHere.transform.position.x > monsterPositionHere.transform.position.x && atackColliderHere.transform.position.x > transform.position.x - atackRange + 3)
                {
                    atackColliderHere.transform.position -= x * Time.deltaTime; ;

                }
                if (atackColliderHere.transform.position.y > monsterPositionHere.transform.position.y && atackColliderHere.transform.position.y > transform.position.y - atackRange + 3)
                {
                    atackColliderHere.transform.position -= y * Time.deltaTime; ;
                }

                if (atackColliderHere.atackHit == true)
                {
                    float tan = 0;
                    //Quaternion q;
                    // Vector3 v;
                    HitColliderEnabled();


                    if (relativePosition.x == 0)
                    {
                        if (relativePosition.y < 0)
                        {
                            tan = 180;
                        }
                        else if (relativePosition.y > 0)
                        {
                            tan = 0;
                        }


                    }
                    else if (relativePosition.y == 0)
                    {
                        if (relativePosition.x < 0)
                        {
                            tan = 90;
                        }
                        else if (relativePosition.x > 0)
                        {
                            tan = 270;
                        }

                    }
                    else if (relativePosition.x < relativePosition.y)
                    {
                        tan = relativePosition.x / relativePosition.y;
                        tan *=   (180f / 3.14159265359f);

                    }
                    else if (relativePosition.x > relativePosition.y)
                    {
                        tan = relativePosition.y / relativePosition.x;
                        tan *= (180f / 3.14159265359f);

                    }
                    else
                    {
                        tan = 1;
                        tan *=  (180f / 3.14159265359f);
                    }
                   
                 
                 //   Debug.Log("X: " + relativePosition.x); Debug.Log("Y: " + relativePosition.y); Debug.Log("TAN: " + tan);
                    /*
                   Debug.Log(tan);
                   float rad = (180f / 3.14159265359f)/4;
                  v.z = tan;
                   v.x = 0;
                   v.y =0;
                   q = Quaternion.Euler(v);*/
                   
                  
                    if (positionAtibuited == false)
                    {
                        tanValue = tan;
                        atackHitColliderHere.transform.rotation = Quaternion.Euler(0f, 0f, tanValue - 20);
                        positionAtibuited = true;
                       

                    }
                    else if (timeCountAtack < 5f)
                    {
                        timeCountAtack +=0.1f;
                        
                        atackHitColliderHere.transform.rotation = Quaternion.Euler(0f, 0f, multiplyingZ = multiplyingZ * atackSpeed);

                       
                    }
                    else
                    {

                        multiplyingZ = 1;
                        timeCountAtack = 0;
                        positionAtibuited = false;
                        tanValue = 0;
                  
                    }



                }
                else
                {
                    multiplyingZ = 1;
                    timeCountAtack = 0;
                    positionAtibuited = false;
                    tanValue = 0;
                    HitColliderDisabled();
                }

            }
            else
            {
                atackColliderHere.transform.position = lastPosition;
               
                    
            }




                /*else
                {
                    Debug.Log("21333333333333333333333333333333");
                    timeToAtack = 2;
                    atackColliderHere.colliderAtack.transform.position = transform.position;

                    ColliderDisabled();
                }
               */

                /*
                Vector3 initialPoint = new Vector3(0, 0, 0);
                atackColliderHere.colliderAtack.transform.position = initialPoint;
                */

            }
            else
            {

                // timeToAtack = 2;
                atackColliderHere.colliderAtack.transform.position = transform.position; 

                ColliderDisabled();
            }
            timeToAtack -= Time.deltaTime;

        
    }

    public void ColliderEnabled()
    {
        atackColliderHere.colliderAtack.enabled = true;
    }
    public void ColliderDisabled()
    {
        atackColliderHere.colliderAtack.enabled = false;
    }

    public void HitColliderEnabled()
    {
        atackHitColliderHere.colliderHitAtack.enabled = true;
        atackHitColliderHere.spritHitBox.enabled =  true;
    }
    public void  HitColliderDisabled()
    {
        atackHitColliderHere.colliderHitAtack.enabled  = false;
        atackHitColliderHere.spritHitBox.enabled = false;
    }

}

