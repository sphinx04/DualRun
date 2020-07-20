using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    void Update()
    {
        if (transform.position.z < -(transform.localScale.z + 25))
        {
            FloorManager.Instance.floors.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        transform.position += Vector3.back * (Time.deltaTime * FloorManager.Instance.floorSpeed);
    }
}
