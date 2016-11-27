using UnityEngine;

public class SimpleAIScript : BaseAIScript {
    float deltaTime = 0.0f;

    // Use this for initialization
    protected override void Start () {
        base.Start();

    }
	
	// Update is called once per frame
	void FixedUpdate() {

        if (Input.GetKeyDown(KeyCode.Space))
            Log("Нажата кнопка \"Пробел\"");

        if (!_pathBehaviourScript.isPathProviderExist())
        {
            _carEngineScript.SetWheelTurn(0);
            _carEngineScript.SetEnginePower(0);
            _carEngineScript.SetBrake(1);
            return;
        }
        else
        {
            _carEngineScript.SetBrake(0);
        }

        if (_pathBehaviourScript.GetLimitedValue() != -1 && _pathBehaviourScript.GetLimitedValue() < _carEngineScript.GetSpeed())
            _carEngineScript.SetBrake(1);

        var breakForce = GetBreakForce();

        if (breakForce > 0)
            _carEngineScript.SetBrake(breakForce);

        var angleToWaypoint = GetAngleToPoint();
        _carEngineScript.SetWheelTurn(angleToWaypoint);
        var carEnginePower = breakForce <= 0 ? _pathBehaviourScript.GetCurrentSpeedMultilplayer() : 0;

        if (_carEngineScript.GetSpeed() >= _pathBehaviourScript.GetLimitedValue())
        {
            carEnginePower = 0;
            //_carEngineScript.SetBrake(1);
        }
        else
        if (_carEngineScript.GetSpeed() >= _pathBehaviourScript.GetLimitedValue() - 5)
        {
            carEnginePower *= (_pathBehaviourScript.GetLimitedValue() - _carEngineScript.GetSpeed()) / 10;
        }

        _carEngineScript.SetEnginePower(carEnginePower);
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        OnFps();
    }

    private float GetBreakForce()
    {
        Ray ray = new Ray(transform.position + transform.forward * 3, transform.forward);
        Debug.DrawLine(transform.position + transform.forward * 3, transform.position + transform.forward * 13);

        var hits = Physics.RaycastAll(ray, 10);
        foreach(var hit in hits)
        {
            if (hit.collider.isTrigger)
            {
                var script = hit.transform.gameObject.GetComponent<LightControlScript>();
                if (script != null && script.GetState() != 3)
                    return hit.distance < 5 ? 1 : (10 - hit.distance) / 10;
            }
        }

        return 0;
    }

    private float GetAngleToPoint()
    {
        var targetPoint = this._pathBehaviourScript.GetCurrentPoint();
        var carPosition = this.transform.position;
        var wheelGlobalRotation = transform.rotation.eulerAngles.y + _carEngineScript._wheelAngle;
        if (wheelGlobalRotation > 360)
            wheelGlobalRotation -= 360;
        if (wheelGlobalRotation < 0)
            wheelGlobalRotation += 360;

        Vector3 relativePos = new Vector3(targetPoint.x, 0, targetPoint.z) - new Vector3(carPosition.x, 0, carPosition.z);
        var targetRotation = Quaternion.LookRotation(relativePos).eulerAngles;

        var rotationSpeed = 60f;

        if (Mathf.Abs(wheelGlobalRotation +  - targetRotation.y) < 30)
            rotationSpeed = (float)(Mathf.Abs(wheelGlobalRotation - targetRotation.y));

        var angleDelta = MoveTo(wheelGlobalRotation, targetRotation.y, rotationSpeed);
        angleDelta = angleDelta - transform.rotation.eulerAngles.y;
        return angleDelta;
    }

    private float MoveTo(float from, float to, float speed)
    {
        if (from < 0)
            from += 360;

        if (Mathf.Abs(to - from) > 180)
        {
            if(to > from)
                to -= 360;
            else
                to += 360;
        }

        var result = 0f;
        if (to > from)
            result = from + speed;
        if (to < from)
            result = from - speed;

        if (speed > Mathf.Abs(to - from))
            result = to;
        return result;
    }

    void OnFps()
    {        
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
    }
}
