using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 velocity;
    public float SPEED;
    private Rigidbody rb;
    // Start is called before the first frame update
    public bool isGrounded;
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
