using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class clientSpawner : MonoBehaviour
{


    public Transform leavingPoint;
    public float rangeMin;
    public float rangeMax;

    public Vector3 spawnArea;

    public float time;

    public float minTime;
    public float maxTime;
    public float randomNumber;
    public int clientSpawned;
    public int clientsMaxNum;
    public int clientAmout;




    public int clientNumber;
    public int numberOfDiferentClients;
    /* public GameObject marcio;
     public GameObject lidia;
     public GameObject steve;*/

    [System.Serializable]
    public class prefabData
    {
       
        public GameObject prefab;
        public int clientSpawned;
        public int clientsMaxNum;

    }

    
    public List<prefabData> prefabs = new List<prefabData>();
   
    // Start is called before the first frame update
    void Start()
    {   
        
        time = maxTime;
       


    }

    // Update is called once per frame
   


    private void Update()
    {
        clientAmout  = prefabs.Count;
        randomNumber = Random.Range(0, clientAmout);
       clientSpawner2((int)randomNumber);
    }

    void clientSpawner2(int prefabIndex)
    {

        if (time <= 0f)
        {


            if (prefabs[prefabIndex].clientSpawned < prefabs[prefabIndex].clientsMaxNum)
            {
                Vector3 spawnArea = new Vector3( leavingPoint.transform.position.x + Random.Range(rangeMin, rangeMax),leavingPoint.transform.position.y + Random.Range(rangeMin, rangeMax), leavingPoint.transform.position.z);
                Instantiate(prefabs[prefabIndex].prefab, spawnArea  , Quaternion.identity);
                prefabs[prefabIndex].clientSpawned++;
            }


            randomNumber = Random.Range(minTime, maxTime);
            time = randomNumber;
        }

        time -= Time.deltaTime;
    }

    public void prefabDestroyed(int prefabIndex)
    {
        if (prefabs[prefabIndex].clientSpawned > 0)
        {
            clientSpawner2(prefabIndex);
            prefabs[prefabIndex].clientSpawned--;
        }
    }
}


