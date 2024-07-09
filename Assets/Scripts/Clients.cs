using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clients: MonoBehaviour
{

    public GameObject clientsPrefab;
    public Transform clientsLeavingPoint;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject pineapple = Instantiate(clientsPrefab, clientsLeavingPoint.position, Quaternion.identity);
        }
    }
}
