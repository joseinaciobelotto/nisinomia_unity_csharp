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

    public float strenght = 0.01f;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        colliderHitAtack = GetComponent<BoxCollider2D>();
        spritHitBox = GetComponentInChildren<SpriteRenderer>();
        monsterFighterHere = FindAnyObjectByType<monsterFighter>();
        movementHere = FindAnyObjectByType<Movement>();

    }

    // Update is called once per frame
    void Update()
    {

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
                if (movementHere.timeCountAtack > 0)
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
}
