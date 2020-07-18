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
        floors.Add(Instantiate(newObject, 
            new Vector3(0, -1, newObject.transform.localScale.z * (floors.Count) + floors[0].transform.position.z), 
            new Quaternion()));
    }
}
