using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector3 velocity;
    public float MAX_SPEED;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime*MAX_SPEED, Space.Self);
    }

    public void Move(InputAction.CallbackContext context){
        Vector2 move = context.ReadValue<Vector2>();
        velocity.x = move.x;
        velocity.z = move.y;
    }
}
