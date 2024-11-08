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
    [SerializeField] Rigidbody rb;
    [SerializeField] public float force = 10f;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 curScreenPoint;
    private Vector3 curPosition;
    public bool isDragging = false;
    public Vector3 currentVelocity;
    public bool forceApplied = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0,-4,0); 
    }

    // Update is called once per frame
    void Update()
    {
        // https://discussions.unity.com/t/dragging-constrained-to-radius-with-decay/570092/5
        originPosition = new Vector3(transform.position.x,transform.position.y, 0);
        mousePosition = Input.mousePosition;
        mousePosition.z = 0;
    }

    void OnMouseDown() {
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

    }

    void OnMouseUp()
    {
        
    }
}
