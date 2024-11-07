using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 mousePosition;
    [SerializeField] Rigidbody rb;
    [SerializeField] public float force = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        //rb.AddForce((mousePosition - transform.position).normalized * force);  
        Debug.Log(transform.position);
    }
}
