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
    public float jumpForce = 30f;

    public Transform groundCheck;

    private bool grounded;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        Collider[] colls = Physics.OverlapSphere(groundCheck.position, .2f);
        grounded = colls.Length > 1;
        print(colls.Length);
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
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            //rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            MoveUp();
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

    private void Move(Vector3 distance)
    {
        transform.position += distance;
        particleSystem.Play();
        CM_Shaker.amplitude = .5f;
    }

    public void MoveLeft()
    {
        if (transform.position.x > -distance * (rowCount - 1))
            Move(new Vector3(-distance,0,0));
    }    
    public void MoveRight()
    {
        if (transform.position.x < distance * (rowCount - 1))
            Move(new Vector3(distance,0,0));
    }
    public void MoveUp()
    {
        Move(new Vector3(0,3,0));
        rigidbody.useGravity = false;
        StartCoroutine(RestoreGravity());

    }

    IEnumerator RestoreGravity()
    {
        yield return new WaitForSeconds(.1f);
        rigidbody.useGravity = true;
    }
    
}

