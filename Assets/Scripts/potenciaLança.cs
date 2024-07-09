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
    
    // Start is called before the first frame update
    void Start()
    {
       colid =GetComponent<BoxCollider2D>();
        power = GetComponent<Rigidbody2D>();
        vertical = FindAnyObjectByType<Movement>();
        horizontal = FindAnyObjectByType<Movement>();
        distY = power.transform.position.y;
        distX = power.transform.position.x;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (test <= 0) {
            direction = new Vector3(vertical.animHorizontal, vertical.animVertical, 0);
            test = 1;

        
        }
    }
    private void FixedUpdate()
    {

        power.transform.position += direction * speed;

        destroyBullet();

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
