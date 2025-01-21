using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveVelocity;
    private bool isMovingRight;
    private int directionChanges = 3;
    void Start()
    {
        
    }
    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3((isMovingRight ? moveVelocity : -moveVelocity) * Time.deltaTime, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
    }


    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Wall")
        {
            isMovingRight = !isMovingRight;
            directionChanges--;
        }

        if (directionChanges == 0) GameObject.Destroy(this.gameObject);
    }
}
