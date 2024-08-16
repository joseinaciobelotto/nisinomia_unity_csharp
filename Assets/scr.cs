using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scr : MonoBehaviour
{
    public monsterFighter movementHere;
    public float range;
    public Rigidbody2D rb;
    public float distance;

    public Vector3 x = new Vector3(1, 0, 0);
    public Vector3 y = new Vector3(0, 1, 0);
    public float speed;
    public float speedBefore;
    // Start is called before the first frame update
    void Start()
    {
        movementHere = FindAnyObjectByType<monsterFighter>();
        rb = FindAnyObjectByType<Rigidbody2D>();

    }
    private void Update()
    {
        distance = Mathf.Pow((transform.position.y - movementHere.transform.position.y), 2) + Mathf.Pow((transform.position.x - movementHere.transform.position.x), 2);
        speed = distance * speedBefore;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        


        if (transform.position.x < (movementHere.transform.position.x + range) && transform.position.x > (movementHere.transform.position.x - range) &&
          transform.position.y < (movementHere.transform.position.y + range) && transform.position.y > (movementHere.transform.position.y - range))
        {
            if (transform.position.x < movementHere.transform.position.x && transform.position.x < movementHere.transform.position.x + range )
            {
                transform.position += speed * x;

            }
            if (transform.position.y < movementHere.transform.position.y && transform.position.y < movementHere.transform.position.y + range )
            {
                transform.position += speed * y; 
            }
            if (transform.position.x > movementHere.transform.position.x && transform.position.x > movementHere.transform.position.x - range )
            {
                transform.position -= speed * x; 

            }
            if (transform.position.y > movementHere.transform.position.y && transform.position.y > movementHere.transform.position.y - range)
            {
                transform.position -= speed * y;
            }
        }
    }
}
