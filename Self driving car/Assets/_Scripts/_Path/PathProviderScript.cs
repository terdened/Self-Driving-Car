using UnityEngine;
using System.Collections;

public class PathProviderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Transform GetPoint(int index)
    {
        return this.transform.GetChild(index);
    }

    public float GetMaxSpeed(int index)
    {
        var script = this.transform.GetChild(index).GetComponent<PathPointBehaviourScript>();
        return script.SpeedMultiplier;
    }

    public bool GetBreakValue(int index)
    {
        var script = this.transform.GetChild(index).GetComponent<PathPointBehaviourScript>();
        return script.BreakValue;
    }

    public float GetLimitedSpeedValue(int index)
    {
        var script = this.transform.GetChild(index).GetComponent<PathPointBehaviourScript>();
        return script.SpeedLimit;
    }

    public int Count()
    {
        return this.transform.childCount;
    }
}
