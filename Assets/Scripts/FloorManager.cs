using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloorManager : MonoBehaviour
{
    public static FloorManager Instance;
    public int floorsOnLoad = 3;
    public float floorSpeed = 10f;
    public List<GameObject> poolOfFloors;

    public List<GameObject> floors;
    
    void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        AddFloorPlatform();
    }

    void Update()
    {
        if (floors.Count < floorsOnLoad)
        {
            AddFloorPlatform();
        }
    }

    public void AddFloorPlatform()
    {
        GameObject newObject = poolOfFloors[Random.Range(0, poolOfFloors.Count - 0)];
        float floorsLenght = 0;

        foreach (GameObject item in floors)
        {
            floorsLenght += item.transform.localScale.z;
        }


        floorsLenght += (newObject.transform.localScale.z - floors[0].transform.localScale.z) / 2;

        floors.Add(Instantiate(newObject, new Vector3(0, -1, floorsLenght + (floors[0].transform.position.z)), new Quaternion()));
    }
}
