using UnityEngine;
using System.Collections;

public class CameraControlScript : MonoBehaviour {

    private int _CameraDistance = 7;
    public GameObject Car;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Car == null)
            return;

        var cameraPosition = new Vector3(Car.transform.position.x, Car.transform.position.y, Car.transform.position.z);
        cameraPosition.x += Mathf.Cos(-(Car.transform.rotation.eulerAngles.y + 90) * 3.14f / 180) * _CameraDistance;
        cameraPosition.z += Mathf.Sin(-(Car.transform.rotation.eulerAngles.y + 90) * 3.14f / 180) * _CameraDistance;
        cameraPosition.y = 3f;

        transform.position = cameraPosition;
        transform.LookAt(Car.transform.position);
	}
}
