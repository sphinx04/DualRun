using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    public float distance = 3;
    public int rowCount = 3;
    public ParticleSystem particleSystem;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.name);

        if (collision.gameObject.tag == "Obstacle")
        {
            print("sdcsdfsdfsdf");
            FloorManager.Instance.floorSpeed = 0;
            Destroy(gameObject, 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.name);

        if (other.gameObject.tag == "Obstacle")
        {
            print("sdcsdfsdfsdf");
            FloorManager.Instance.floorSpeed = 0;
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }
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
    }

    public void MoveLeft()
    {
        if (transform.position.x > -distance * (rowCount - 1))
            Move(-distance);
    }    
    public void MoveRight()
    {
        if (transform.position.x < distance * (rowCount - 1))
            Move(distance);
    }
    
}

