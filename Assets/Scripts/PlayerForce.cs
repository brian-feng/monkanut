using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PlayerForce : MonoBehaviour
{
    public Ball ball;
    private Rigidbody rb;
    private Vector3 originPosition;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.isDragging)
        {
            rb.isKinematic = true;
        }
        if (ball.forceApplied) {
            rb.isKinematic = false;
            originPosition = new Vector3(transform.position.x,transform.position.y, 0);

            ApplyForce(ball.currentVelocity);
            ball.forceApplied = false;
        }
        if (ball.isDragging) { // TODO: make it so that its kinematic only when its grounded
            rb.isKinematic = true;
        } else {
            rb.isKinematic = false;
        }
    }

    private void ApplyForce(Vector3 velocity) {
        Debug.Log("force applied");
        // rb.AddForce(velocity.normalized * 10f, ForceMode.Force);  

        rb.AddForce(velocity, ForceMode.Force);  

    }

    private void OnCollisionStay(Collision collision) {
        // if player is colliding with floor
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        // if player is colliding with floor
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
}
