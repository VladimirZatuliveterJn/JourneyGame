using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float _speed;
    public float walkspeed = 0.05f;
    public float runspeed = 0.15f;

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
        if (Input.GetKey(KeyCode.LeftShift))
            _speed = runspeed;
        else
            _speed = walkspeed;
    }
}
