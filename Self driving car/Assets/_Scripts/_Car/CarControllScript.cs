using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(CarScriptBehavior))]
public class CarControllScript : MonoBehaviour {
    private float _wheelAngle;
    private CarScriptBehavior _carEngineScript;


    // Use this for initialization
    void Start () {
        _carEngineScript = this.GetComponent<CarScriptBehavior>();
    }
	
	// Update is called once per frame
	void Update () {
        HandleWheelTurn();
        float v = Input.GetAxis("Vertical");
        float h = _wheelAngle * ((float)Math.PI / 360f);

        _carEngineScript.SetEnginePower(v);
        _carEngineScript.SetWheelTurn(h * 180/Mathf.PI);

        if (Input.GetKey(KeyCode.Space))
        {
            _carEngineScript.SetBrake(1);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _carEngineScript.SetBrake(0);
        }
    }

    private void HandleWheelTurn()
    {
        _wheelAngle = Input.mousePosition.x - Screen.width / 2;
        _wheelAngle *= 0.4f;
        if (_wheelAngle > 60)
            _wheelAngle = 60;

        if (_wheelAngle < -60)
            _wheelAngle = -60;
    }
}
