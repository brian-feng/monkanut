using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector3 velocity;

    public Vector3 _direction;
    public float MAX_SPEED;
    public float _speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("is moving");
        // transform.Translate(velocity * Time.deltaTime*MAX_SPEED, Space.Self);
        transform.Translate(_direction * (_speed * Time.deltaTime));
    }

    public void Move(InputAction.CallbackContext context){
        Debug.Log("is moving");
        // Vector2 move = context.ReadValue<Vector2>();
        // velocity.x = move.x;
        // velocity.z = move.y;
        _direction = context.ReadValue<Vector2>();

    }
}
