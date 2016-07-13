using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CarScriptBehavior : MonoBehaviour {

    public float MotorForce;
    public float SteerForce;
    public float BreakForce;
    public float WheelTurnSpeed;
    public WheelCollider WheelColFR;
    public WheelCollider WheelColFL;
    public WheelCollider WheelColRR;
    public WheelCollider WheelColRL;
    public float _wheelAngle;
    private float _enginePower;
    private bool _brake;

    // Use this for initialization
    void Start()
    {
        _wheelAngle = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WheelColRL.motorTorque = _enginePower * MotorForce;
        WheelColRR.motorTorque = _enginePower * MotorForce;

        WheelColFL.steerAngle = _wheelAngle * SteerForce;
        WheelColFR.steerAngle = _wheelAngle * SteerForce;

        if(_brake)
        {
            WheelColRL.brakeTorque = BreakForce;
            WheelColRR.brakeTorque = BreakForce;
        }
        else
        {
            WheelColRL.brakeTorque = 0;
            WheelColRR.brakeTorque = 0;
        }
    }

    public void SetEnginePower(float value)
    {
        _enginePower = value;
    }

    public void SetWheelTurn(float value)
    {
        _wheelAngle = value * Mathf.PI / 180;

    }

    private float MoveTo(float from, float to, float speed)
    {
        if (to > 180)
            to -= 360;

        if (to < -180)
            to += 360;

        var result = 0f;
        if (to > from)
            result = from + speed;
        if (to < from)
            result = from - speed;

        if (speed > Mathf.Abs(to - from))
            result = to;
        return result;
    }

    public void SetBrake(bool value)
    {
        _brake = value;
    }
}
