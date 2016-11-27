using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PathPointBehaviourScript : MonoBehaviour {

    public bool IsTriggered;
    public float SpeedMultiplier = 1;
    public bool BreakValue = false;
    public float SpeedLimit = -1;
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
