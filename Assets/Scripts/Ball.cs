using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 mousePosition;
    private Vector3 originPosition;

    [SerializeField] public GameObject anchor;
    [SerializeField] Rigidbody rb;
    [SerializeField] public float force = 10f;
    private Vector3 screenPoint;
    private Vector3 offset;

    public float distance;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // https://discussions.unity.com/t/dragging-constrained-to-radius-with-decay/570092/5
        originPosition = new Vector3(anchor.transform.position.x,anchor.transform.position.y, 0);
        mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        // // Debug.Log(mousePosition.x);
        // // Debug.Log(mousePosition.y);
        // if (Input.GetButtonDown("Fire1")) {
        //     // Debug.Log("applying force");
        //     OnMouseDown();
        //     // rb.AddForce((mousePosition - transform.position).normalized * force);
        // }

        // https://discussions.unity.com/t/drag-gameobject-with-mouse/1798/8

    }
    void OnMouseDown() {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }


    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        // Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint + offset);

        // distance = Vector3.Distance(originPosition, curPosition);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

        //rb.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * force, ForceMode.Impulse);  
        //Debug.Log(transform.position);
    }
}
