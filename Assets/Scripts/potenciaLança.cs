using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lauchPower : MonoBehaviour
{

   public  Rigidbody2D power;
    public float speed;
    public Vector3 direction;
    public float distY;
    public float distX;
    public int distG;
    public Movement vertical;
    public Movement horizontal;
    int test;
    public BoxCollider2D colid;

    public Vector3 tan;

    public laucher laucher;
    

    // Start is called before the first frame update
    void Start()
    {
       colid =GetComponent<BoxCollider2D>();
        power = GetComponent<Rigidbody2D>();
        vertical = FindAnyObjectByType<Movement>();
        horizontal = FindAnyObjectByType<Movement>();
        distY = power.transform.position.y;
        distX = power.transform.position.x;
        laucher = FindAnyObjectByType<laucher>();


    }

    // Update is called once per frame
    void Update()
    {
        if (test <= 0) {



            atack(laucher.poitZero.transform.position, laucher.mouseObject.transform.position);



                //direction = new Vector3(mouseObject., l, 0);
            test = 1;

        
        }
    }
    private void FixedUpdate()
    {







        power.transform.position += tan * speed;

        destroyBullet();

     }

    void atack(Vector3 zero, Vector3 mouse)
    {


        float catOp = 0f;
        float catAdj = 0f;
        float angle = 0f;

        catOp = Mathf.Abs(zero.x - mouse.x);
        catAdj = Mathf.Abs(zero.y - mouse.y);

        if (mouse.y > zero.y)
        {
           
        }else
        {
            catAdj *= (-1);
        }

        if (mouse.x > zero.x)
        {
           
        }
        else
        {
            catOp *= (-1);
        }

        tan = new Vector3(catOp, catAdj, 0);

        Debug.Log("zero.y: " + zero.y + ", zero.x: " + zero.x +
           ", mouse.x: " + mouse.x + ", mouse.y: " + mouse.y +
           ", catOp: " + catOp + ", catAdj: " + catAdj);
    }

    void destroyBullet()
    {
        if (power.transform.position.x > distX + distG || power.transform.position.x < -(distX + distG))
        {
            Destroy(gameObject);

        }
        if (power.transform.position.y > distY + distG || power.transform.position.y < -(distY + distG))
        {
            Destroy(gameObject);

        }
    }

}
