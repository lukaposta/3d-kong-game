using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float moveVelocity;
    public float climbVelocity;
    private bool isGrounded;


    void Update()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey("a") && Input.GetKey("d"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
            Quaternion targetRotation = Quaternion.Euler(-90, 0, 180);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10);
        }
        else if (Input.GetKey("d"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(moveVelocity * Time.deltaTime, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
            Quaternion targetRotation = Quaternion.Euler(-90, 0, 120);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10);
        }
        else if (Input.GetKey("a"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(-moveVelocity * Time.deltaTime, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
            Quaternion targetRotation = Quaternion.Euler(-90, 0, 210);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10);
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
            Quaternion targetRotation = Quaternion.Euler(-90, 0, 180);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (c.gameObject.GetComponent<EnemyController>() != null)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.GetComponent<LadderController>() != null)
        {
            if (Input.GetKey("w"))
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, climbVelocity * Time.deltaTime, this.GetComponent<Rigidbody>().velocity.z);
            }
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Chest")
        {
            Time.timeScale = 0;
        }
    }
}
