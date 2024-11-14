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
    [SerializeField] public PlayerController playerController;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 curScreenPoint;
    private Vector3 curPosition;
    public bool isDragging = false;
    public Vector3 currentVelocity;
    public bool forceApplied = false;
    public float speed;
    public bool isInFront;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 0.1f;
        rb.angularDrag = 0.1f;
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
        // curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        // curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        isDragging = true;
        StartCoroutine(CalcSpeed());
        // obtain the current cursor position
        // from the current cursor position 

    }


    void OnMouseDrag()
    {
        // applies force when dragging
        // rb.AddForce((mousePosition - originPosition).normalized * force, ForceMode.Force);  
        curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        // transform.position = curPosition;
        Vector3 directionToMouse = (curPosition - originPosition).normalized;
        rb.AddForce(directionToMouse * force, ForceMode.Force);
        rb.AddForce(-directionToMouse * force * 0.5f, ForceMode.Force); 

        isDragging = true;
        forceApplied = false;
    }

    void OnMouseUp()
    {
        forceApplied = true;
        isDragging = false;
        speed = 0;
        currentVelocity = rb.velocity;
        Debug.Log("no drag");
    }

    void FixedUpdate() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0,0, 1) , out hit)) {
            isInFront = true;
        }

        // obtain the backwall position
    }


    IEnumerator CalcSpeed()
    {
        // https://www.youtube.com/watch?v=tJfJOMIMglE&t=4s
        // bool isPlaying = true;

        while (isDragging) {
            Vector3 prevPos = transform.position;

            yield return new WaitForFixedUpdate();

            speed = Mathf.RoundToInt(Vector3.Distance(transform.position, prevPos) / Time.fixedDeltaTime);
        }
    }
}
