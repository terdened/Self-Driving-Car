using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PathPointBehaviourScript : MonoBehaviour {

    public bool IsTriggered;
	// Use this for initialization
	void Start () {
        IsTriggered = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        IsTriggered = true;
    }

    void OnTriggerExit(Collider other)
    {
        IsTriggered = false;
    }
}
