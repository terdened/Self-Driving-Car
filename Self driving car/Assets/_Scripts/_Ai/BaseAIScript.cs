using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CarScriptBehavior))]
public class BaseAIScript : MonoBehaviour {
    protected PathBehaviourScript _pathBehaviourScript;
    protected CarScriptBehavior _carEngineScript;

    // Use this for initialization
    protected virtual void Start () {
        _pathBehaviourScript = GameObject.Find("Path_manager").GetComponent<PathBehaviourScript>();
        _carEngineScript = this.GetComponent<CarScriptBehavior>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
