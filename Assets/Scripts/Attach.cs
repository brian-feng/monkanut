using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attach : MonoBehaviour
{
    // using the current rope 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject newObj = collision.gameObject;
        attachObject(newObj);
    }

    private void attachObject(GameObject obj) {
        if (obj.CompareTag("Interactable")) {
            obj.transform.parent = transform;
        }
    }
}
