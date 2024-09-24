using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atackHitColliderPlayer : MonoBehaviour
{

    public BoxCollider2D colliderHitAtack;
    public SpriteRenderer spritHitBox;
    public monsterFighter monsterFighterHere;
    public monsterColision monsterColisionHere;

    public Movement movementHere;

    public bool positionAtibuited = false;

    public float strenght = 0.01f;
    public Vector3 direction;

    public float timeCountAtack = 0;
    public float multiplyingZ = 0;
    public float multiplyingZRepeat = 0;
    public float tanValue = 0;

    public atackHitColliderPlayer atackHitPlayerHere;
    public atackColliderPlayer atackPlayerHere;

    public GameObject poitZero;
    public GameObject mouseObject;

    public Vector3 relativePositionMouse;
    public Vector3 poitZeroPosition;
    public float tan = 0;

    public Movement timeToAtackHere; 

    // Start is called before the first frame update
    void Start()
    {
        colliderHitAtack = GetComponent<BoxCollider2D>();
        spritHitBox = GetComponentInChildren<SpriteRenderer>();
        monsterFighterHere = FindAnyObjectByType<monsterFighter>();
        movementHere = FindAnyObjectByType<Movement>();
        atackPlayerHere = FindAnyObjectByType<atackColliderPlayer>();
        timeToAtackHere = FindAnyObjectByType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (movementHere.timeToAtack < 0)
            {
                movementHere.timeToAtack = 0.3f;
                timeCountAtack = 0;
                tanValue = 0;



                Vector3 y = new Vector3(0, 3, 0);
                Vector3 x = new Vector3(3, 0, 0);


                multiplyingZ = multiplyingZRepeat;


                tan = 0;






            }

        }

        if (movementHere.timeToAtack > 0)
        {
            movementHere.timeToAtack -= 0.01f;
            Atacking(poitZero.transform.position, mouseObject.transform.position);
           // Debug.Log("mouse position on screen :" + mouseObject.transform.position);
        }
        else
        {

            multiplyingZ = multiplyingZRepeat;

            positionAtibuited = false;

            HitColliderDisabled();
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {

            monsterColisionHere = collision.gameObject.GetComponent<monsterColision>();
            monsterColisionHere.lifeNow -= monsterFighterHere.damage;

            if (monsterColisionHere.lifeNow - monsterFighterHere.damage < 0)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                if (timeCountAtack > 0)
                {
                    direction = new Vector3(monsterColisionHere.transform.position.x, monsterColisionHere.transform.position.y, 0);
                    monsterColisionHere.haste.AddForce(transform.InverseTransformPoint(direction) * strenght, ForceMode2D.Impulse);
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {


        }
    }


    public void Atacking(Vector3 zero, Vector3 mouse)
    {

        //float range = 0;
        float catOp = 0f;
        float catAdj = 0f;
        float angle = 0f;



        //Quaternion q;
        // Vector3 v;
        HitColliderEnabled();


        if (positionAtibuited == false)
        {


            if (zero.x == mouse.x)
            {
                if (zero.y < mouse.y)
                {
                    angle = 180f;
                }
                else if (zero.y > mouse.y)
                {
                    angle = 0;
                }


            }
            else if (zero.y == mouse.y)
            {
                if (zero.x > mouse.x)
                {
                    angle = 90f;
                }
                else if (zero.x < mouse.x)
                {
                    angle = 270f;

                }
            }
            else if (zero.x > mouse.x)
            {

                if (zero.y < mouse.y)
                {
                    angle = 0f;
                    catOp = Mathf.Abs(zero.x - mouse.x);
                    catAdj = Mathf.Abs(zero.y - mouse.y);

                    tan = Mathf.Atan2(catOp, catAdj) * Mathf.Rad2Deg + angle;


                }
                else if (zero.y > mouse.y)
                {
                    angle = 90f;
                    catOp = Mathf.Abs(zero.x - mouse.x);
                    catAdj = Mathf.Abs(zero.y - mouse.y);

                    tan = Mathf.Atan2(catAdj, catOp) * Mathf.Rad2Deg + angle;


                }
            }
            else if (zero.x < mouse.x)
            {
                if (zero.y < mouse.y)
                {
                    angle = 270f;
                    catOp = Mathf.Abs(zero.x - mouse.x);
                    catAdj = Mathf.Abs(zero.y - mouse.y);

                    tan = Mathf.Atan2(catAdj, catOp) * Mathf.Rad2Deg + angle;

                }
                else if (zero.y > mouse.y)
                {
                    angle = 180f;
                    catOp = Mathf.Abs(zero.x - mouse.x);
                    catAdj = Mathf.Abs(zero.y - mouse.y);

                    tan = Mathf.Atan2(catOp, catAdj) * Mathf.Rad2Deg + angle;

                }
            }
            else
            {
                angle = 360f;


            }

            /*Debug.Log("aaaaaaaaa" + angle);
            Debug.Log("ttttttttt" + tan);

            Debug.Log("aaaaaaaaa" + angle);*/


            /* if (tan - range < 180)
             {
                 tan -= range;
             }
             else if (tan - range < 180)
             {
                 tan = range-180;
             }*/

            //range = 60;

            transform.rotation = Quaternion.Euler(0f, 0f, tan - 60);
            positionAtibuited = true;
            tanValue = tan - 60;

        }
        else if (timeCountAtack < 1f)
        {
            if (multiplyingZ < 120)
            {

                transform.rotation = Quaternion.Euler(0f, 0f, tanValue + multiplyingZ);
                multiplyingZ += multiplyingZ;
                timeCountAtack += 0.1f;
            }




        }


    }



    public void ColliderEnabled()
    {
        atackPlayerHere.colliderAtack.enabled = true;
    }
    public void ColliderDisabled()
    {
        atackPlayerHere.colliderAtack.enabled = false;
    }

    public void HitColliderEnabled()
    {
        colliderHitAtack.enabled = true;
        spritHitBox.enabled = true;
    }
    public void HitColliderDisabled()
    {
        colliderHitAtack.enabled = false;
        spritHitBox.enabled = false;
    }

}









