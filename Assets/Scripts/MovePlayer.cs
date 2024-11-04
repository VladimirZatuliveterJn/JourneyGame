using System.Runtime.CompilerServices;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float _speed;
    public float walkspeed = 0.05f;
    public float runspeed = 0.15f;

    private float _stamina = 100f;
    public float _staminaspeed = 2f;

    bool isGrounded;
    private Rigidbody Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            this.transform.position += this.transform.forward * _speed;
        if (Input.GetKey(KeyCode.S))
            this.transform.position -= this.transform.forward * _speed;
        if (Input.GetKey(KeyCode.D))
            this.transform.position += this.transform.right * _speed;
        if (Input.GetKey(KeyCode.A))
            this.transform.position -= this.transform.right * _speed;
        
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded && _stamina > 1)
        {
            _speed = runspeed;
            _stamina -= _staminaspeed * Time.deltaTime;
        }
        else
        {
            _speed = walkspeed;
            Invoke("IncreaseStamina", 3);
        }
        Debug.Log(_stamina);

        if (Input.GetKey(KeyCode.Space) && isGrounded && _stamina > 1)
        {
            Rb.AddForce(new Vector3(0, 200f, 0), ForceMode.Impulse);
            _stamina--;
            isGrounded = false;
        }

        Physics.gravity = new Vector3(0, -9.8F, 0);
    }
    void OnCollisionStay()
    	{
    		isGrounded = true;
    	}

    private void IncreaseStamina()
    {
        if (_stamina < 100f)
            _stamina += 1f * Time.deltaTime;
        if (_stamina > 100f)
            _stamina = 100f;
    }
}

