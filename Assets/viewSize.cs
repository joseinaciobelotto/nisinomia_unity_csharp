using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class viewSize : MonoBehaviour
{


    public CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            vcam.m_Lens.OrthographicSize += 2;
        }
        
            if (Input.GetKeyDown(KeyCode.C))
        {
                vcam.m_Lens.OrthographicSize -= 2;
        }
        
    }
}
