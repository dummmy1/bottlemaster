using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleSpawner : MonoBehaviour
{
    List<GameObject> prefabList = new List<GameObject>();
    //public GameObject bottlePrefab;
    public GameObject bottlePrefab2;
    public GameObject npc;
    private float xPos;
    private float yPos;
    private float zPos;


    

    private float bottleTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        //prefabList.Add(bottlePrefab);
        prefabList.Add(bottlePrefab2);

        
       
    }

    // Update is called once per frame
    void Update()
    {
        bottleSpawnTimer();
        xPos = npc.transform.position.x;
        zPos = npc.transform.position.z;
        yPos = npc.transform.position.y;
    }

    //time interval between when the bottles spawn and where are they going to spawn
    void bottleSpawnTimer()
    {
        
        if (Time.time > bottleTime)
        {


            bottleTime += 20;
            int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count);
            Instantiate(prefabList[prefabIndex], new Vector3 (xPos, yPos, zPos) , Quaternion.Euler(0, 0, 0));


            

        }
    
    }
}





