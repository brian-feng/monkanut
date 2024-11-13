using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{  
    // https://www.youtube.com/watch?v=4mzbDk4Wsmk
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
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(patrolPoints[targetPoint].transform.position, 0.5f);
        Gizmos.DrawWireSphere(patrolPoints[targetPoint-1].transform.position, 0.5f);
        Gizmos.DrawLine(patrolPoints[targetPoint].transform.position, patrolPoints[targetPoint-1].transform.position);
    }
}
