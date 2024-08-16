using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : MonoBehaviour
{
    public Vector3 mouseIs;

    public GameObject positon1;
    public GameObject positon2;

    public startButton startButtonHere;
    // Start is called before the first frame update
    void Start()
    {
        startButtonHere = FindAnyObjectByType<startButton>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseIs = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            if (mouseIs.x > positon1.transform.position.x && mouseIs.y > positon1.transform.position.y && mouseIs.x < positon2.transform.position.x && mouseIs.y < positon2.transform.position.y)
            {
               startButtonHere.gameObject.SetActive(false);
            }
        }
    }
}
