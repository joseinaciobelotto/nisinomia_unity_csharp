using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSpawner : MonoBehaviour
{


    public Transform leavingPoint;
    public float rangeMin;
    public float rangeMax;

    public Vector3 spawnArea;

    public float time;

    public float minTime;
    public float maxTime;
    public float randomNumber;
    public int monstersAmout;

    public DayCycle isNight;


    public int clientNumber;
    public int numberOfDiferentClients;
    /* public GameObject marcio;
     public GameObject lidia;
     public GameObject steve;*/

    [System.Serializable]
    public class monsterbData
    {





        public GameObject prefab;
        public int monstersSpawned;
        public int clientsMaxNum;

    }


    public List<monsterbData> monsterPrefabs = new List<monsterbData>();

    // Start is called before the first frame update
    void Start()
    {

        time = maxTime;
        isNight = FindAnyObjectByType<DayCycle>();


    }

    // Update is called once per frame



    private void Update()
    {
        monstersAmout = monsterPrefabs.Count;

        if (isNight == true)
        {
            randomNumber = Random.Range(0, monstersAmout);
            clientSpawner2((int)randomNumber); 
        }
       
    }

    void clientSpawner2(int prefabIndex)
    {

        if (time <= 0f)
        {


            if (monsterPrefabs[prefabIndex].monstersSpawned < monsterPrefabs[prefabIndex].clientsMaxNum)
            {
                Vector3 spawnArea = new Vector3(leavingPoint.transform.position.x + Random.Range(rangeMin, rangeMax), leavingPoint.transform.position.y + Random.Range(rangeMin, rangeMax), leavingPoint.transform.position.z);
                Instantiate(monsterPrefabs[prefabIndex].prefab, spawnArea, Quaternion.identity);
                monsterPrefabs[prefabIndex].monstersSpawned++;
            }





            randomNumber = Random.Range(minTime, maxTime);
            time = randomNumber;
        }

        time -= Time.deltaTime;
    }

    public void prefabDestroyed(int prefabIndex)
    {
        if (monsterPrefabs[prefabIndex].monstersSpawned > 0)
        {
            clientSpawner2(prefabIndex);
            monsterPrefabs[prefabIndex].monstersSpawned--;
        }
    }
}


