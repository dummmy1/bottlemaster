using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstBottle : MonoBehaviour
{
    List<GameObject> prefabList = new List<GameObject>();
    //public GameObject bottlePrefab;
    public GameObject bottlePrefab;
    private float bottleCooldownTime = 1;
    public GameObject garbageBin;
    private float xPos;
    private float yPos;
    private float zPos;
    // Start is called before the first frame update
    void Start()
    {
        //prefabList.Add(bottlePrefab);
        prefabList.Add(bottlePrefab);
        xPos = garbageBin.transform.position.x;
        yPos = garbageBin.transform.position.y;
        zPos = garbageBin.transform.position.z;


    }

    // Update is called once per frame
    void Update()
    {
        BottleRandomTime();


    }

    //time interval between when the bottles spawn and where are they going to spawn


    void BottleRandomTime()
    {

        if (Time.time > bottleCooldownTime)
        {
            bottleCooldownTime += 2;
            int prefabIndex = UnityEngine.Random.Range(0, prefabList.Count);
            Instantiate(prefabList[prefabIndex], new Vector3(xPos, yPos, zPos), Quaternion.identity);
            Instantiate(prefabList[prefabIndex], new Vector3(xPos, yPos, zPos), Quaternion.identity);
            Instantiate(prefabList[prefabIndex], new Vector3(xPos, yPos, zPos), Quaternion.identity);
        }


    }

}
