using UnityEngine;
using System.Collections;

public class WheelControlScript : MonoBehaviour {

    public WheelCollider wheelC;
    public bool IsFront;

    private Vector3 wheelCCenter;
    private RaycastHit hit;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (wheelC == null)
            return;

        wheelCCenter = wheelC.transform.TransformPoint(wheelC.center);

        if (Physics.Raycast(wheelCCenter, -wheelC.transform.up, out hit, wheelC.suspensionDistance + wheelC.radius))
        {
            transform.position = hit.point + (wheelC.transform.up * wheelC.radius *0.8f);
        }
        else
        {
            transform.position = wheelCCenter - (wheelC.transform.up * wheelC.suspensionDistance);
        }

        var rotationValue = 360f * (wheelC.rpm / 60f) * Time.deltaTime;
        transform.rotation 
            = wheelC.transform.rotation 
            * Quaternion.Euler(-rotationValue + transform.rotation.eulerAngles.x, IsFront ? wheelC.steerAngle + 180 : 180, 0);
    }
}
