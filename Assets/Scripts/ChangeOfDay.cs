using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOfDay : MonoBehaviour
{
    public float DayTime = 5; // in minutes
    public float NightTime = 5; // in minutes
    private float DaySpeedX;
    private float NightSpeedX;
    private float nextActionTime;
    private bool IsDay = true;
    private float X;
    private float Y;
    void Start()
    {
        DaySpeedX = DayTime / 3000;
        NightSpeedX = NightTime / 3000;
        X = this.transform.rotation.x;
        Y = this.transform.rotation.y;
    }


    void Update()
    {
        if (IsDay)
        {
            if (Time.time > nextActionTime) 
                {
                    nextActionTime += DaySpeedX;
                    X += 0.01f;
                }
        }
        else
        {
            if (Time.time > nextActionTime) 
                {
                    nextActionTime += NightSpeedX;
                    X += 0.01f;
                }
        }
        
        this.transform.rotation = Quaternion.Euler(X, Y, this.transform.rotation.z);
    }
}
