using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject barriers, empty, floor;
    float positionOfBarrierSpawn;
    float positionOfFloorSpawn;
    float rotation;
    int rot;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBarriers", 0, 3);
        InvokeRepeating("SpawnFloor", 0, 0.25f);
        positionOfBarrierSpawn = 2f;
        positionOfFloorSpawn = 5.64f+3.44f;
        rot = 90;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBarriers() {
        float r = Random.Range(-1.75f, 1.75f);
        Instantiate(barriers, new Vector3(positionOfBarrierSpawn, r, 0), Quaternion.identity);
        Instantiate(empty, new Vector3(positionOfBarrierSpawn + 0.5f, r, 0), Quaternion.identity);
        positionOfBarrierSpawn += 5f;
    }
    void SpawnFloor() {
        GameObject g = Instantiate(floor, new Vector3(positionOfFloorSpawn, 6, 0), Quaternion.identity);
        GameObject h = Instantiate(floor, new Vector3(positionOfFloorSpawn, -6, 0), Quaternion.identity);
        //g.transform.Rotate(new Vector3(0f, 90f + rot, 0f), Space.World);
        //h.transform.Rotate(new Vector3(0f, 90f + rot, 0f), Space.World);
        positionOfFloorSpawn += 3.44f;
        rot = -rot;
    }
}
