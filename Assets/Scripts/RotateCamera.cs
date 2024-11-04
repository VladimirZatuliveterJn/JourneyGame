using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class RotateCamera : MonoBehaviour
{ 
    public float sensitivity = 0.5f;
    private Vector2 turn;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update() 
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        transform.parent.rotation = Quaternion.Euler(0, turn.x, 0);
    }
}
