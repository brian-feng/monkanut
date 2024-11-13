using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 velocity;
    public float SPEED;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Vector3.zero;
        if(Input.GetAxis("Horizontal") != 0){
            velocity.x = Input.GetAxis("Horizontal");
        }
        velocity.Normalize();
        transform.Translate(velocity*Time.deltaTime*SPEED);
        Debug.Log(velocity);
    }

    
    
    
}
