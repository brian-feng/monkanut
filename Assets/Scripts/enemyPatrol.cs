using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{

    // public GameObject pointA;
    // public GameObject pointB;
    // private Rigidbody rb;
    // private Animator anim;
    // private Transform currentPoint;
    // public float speed;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    //     anim = GetComponent<Animator>();
    //     currentPoint = pointB.transform;
    //     anim.SetBool("isRunning", true);
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     // https://www.youtube.com/watch?v=RuvfOl8HhhM
    //     Vector3 point = currentPoint.position - transform.position;
    //     if (currentPoint == pointB.transform)
    //     {
    //         rb.velocity = new Vector3(speed, 0);
    //     } else
    //     {
    //         rb.velocity = new Vector3(-speed, 0);
    //     }

    //     if (Vector3.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
    //     {
    //         currentPoint = pointA.transform;
    //     }
        
    //     if (Vector3.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
    //     {
    //         currentPoint = pointB.transform;
    //     }
    // }

    // private void OnDrawGizmos() {
    //     Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
    //     Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
    //     Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    // }

    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;

    void Start() {
        targetPoint = 0;
    }

    void Update() {
        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }

    void increaseTargetInt()
    {
        targetPoint++;

        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }
}
