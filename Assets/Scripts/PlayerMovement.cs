using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    public float distance = 3;
    public ParticleSystem particleSystem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    private void Move(float distance)
    {
        transform.position += new Vector3(distance,0,0);
        particleSystem.Play();
        CM_Shaker.amplitude = .5f;
        //CameraShaker.Instance.ShakeOnce(1, 1, 0, .5f);
    }

    public void MoveLeft()
    {
        Move(-distance);
    }    
    public void MoveRight()
    {
        Move(distance);
    }
    
}

