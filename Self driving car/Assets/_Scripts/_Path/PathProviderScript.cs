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

    public int Count()
    {
        return this.transform.childCount;
    }
}
