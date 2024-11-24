using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float _speed;
    public float walkspeed = 500f;
    public float runspeed = 800f;

    private float _stamina = 100f;
    public float _staminaspeed = 2f;
    private bool _canRest; // Can increase stamina

    private float _health = 100f;
    private float _damage = 10f;
    private float _punch_delay = 1f;

    bool isGrounded;
    public float JumpForce = 200f;
    private Rigidbody Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate() 
    {
        // Check movement speed
        CheckSpeed();

        // Calculate movement input
        float h = Input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime;
        float v = Input.GetAxis("Vertical") * _speed * Time.fixedDeltaTime;

        // Move the player
        Rb.velocity = transform.TransformDirection(new Vector3(h, Rb.velocity.y, v));

        // Jump if grounded and has stamina
        if (Input.GetKey(KeyCode.Space) && isGrounded && _stamina > 1)
        {
            Rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            _stamina--;
            isGrounded = false;
        }

        // Regenerate stamina
        if (_canRest)
        {
            if (_stamina < 100f)
                _stamina += 1f * Time.deltaTime;
            if (_stamina > 100f)
                _stamina = 100f;
        }

        // Dead if has health less than zero
        if (_health <= 0)
            Destroy(this.gameObject);

        Debug.Log("stamina: " + _stamina);
        Debug.Log("health: " + _health);
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Danger")
            Invoke("Damage", _punch_delay);

        if (other.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void CheckSpeed() // Check speed of move
    {
        // Adjust speed and stamina based on run/walk condition
        if (Input.GetKey(KeyCode.LeftShift) && _stamina > 1)
        {
            _speed = runspeed;
            _stamina -= _staminaspeed * Time.deltaTime;
            _canRest = false;
        }
        else
        {
            _speed = walkspeed;
            _canRest = true;
        }
    }

    void Damage()
    {
        _health =- _damage;
    }
}

