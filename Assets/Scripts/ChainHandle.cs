using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainHandle : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform firstChain;
    private Vector3 mousePosition;
    private Vector3 originPosition;
    [SerializeField] Rigidbody rb;
    [SerializeField] public float force = 10f;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 curScreenPoint;
    private Vector3 curPosition;
    public Vector3 currentVelocity;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(transform.position, firstChain.position);
        rb = GetComponent<Rigidbody>();
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (firstChain != null)
        {
            Gizmos.DrawWireSphere(firstChain.position, distance);
        }
    }

    private void FixedUpdate()
    {
        // https://discussions.unity.com/t/dragging-constrained-to-radius-with-decay/570092/5
        originPosition = new Vector3(transform.position.x, transform.position.y, 0);
        mousePosition = Input.mousePosition;
        mousePosition.z = 0;
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
    }


    void OnMouseDrag()
    {
        curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        Vector3 dir = curPosition - firstChain.transform.position;
        // clamp length
        dir = Vector3.ClampMagnitude(dir, distance);
        // add clamped length
        transform.position = firstChain.transform.position + dir;

    }

    void OnMouseUp()
    {

    }
}