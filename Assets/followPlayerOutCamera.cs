using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerOutCamera : MonoBehaviour
{

    public Vector3 playerPositionFollowing;
    public Rigidbody2D rig;
    public Movement playerPositionNow;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerPositionNow = FindAnyObjectByType<Movement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPositionFollowing = new Vector3(playerPositionNow.transform.position.x, playerPositionNow.transform.position.y, playerPositionNow.transform.position.z);

        rig.transform.position += playerPositionFollowing;
    }
}
