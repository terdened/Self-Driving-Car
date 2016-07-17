using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CarScriptBehavior))]
public class BaseAIScript : MonoBehaviour {
    protected PathBehaviourScript _pathBehaviourScript;
    protected CarScriptBehavior _carEngineScript;
    protected PanelInfoScript _panelInfoScript;

    // Use this for initialization
    protected virtual void Start () {
        _pathBehaviourScript = GameObject.Find("Path_manager").GetComponent<PathBehaviourScript>();
        _panelInfoScript = GameObject.Find("Info_panel").GetComponent<PanelInfoScript>();
        _carEngineScript = this.GetComponent<CarScriptBehavior>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void Log(string text)
    {
        if (_panelInfoScript != null)
            _panelInfoScript.AddDecisionLogRecord(text);
    }
}
