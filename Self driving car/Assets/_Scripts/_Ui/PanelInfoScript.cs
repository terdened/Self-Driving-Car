using UnityEngine;
using UnityEngine.UI;
using System;

public class PanelInfoScript : MonoBehaviour {

    public GameObject DecisionLogContent;
    public Text RpmLabel;
    public Text SpeedLabel;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddDecisionLogRecord(string text)
    {
        var logText = (Text)DecisionLogContent.GetComponentInChildren<Text>();
        logText.text = DateTime.Now.ToString("H:mm:ss ") + text + "\n" + logText.text;
        var logHeight = logText.preferredHeight;

        var rectTransform = (RectTransform)DecisionLogContent.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(0, logHeight);
    }

    public void SetSpeedValue(int value)
    {
        SpeedLabel.text = String.Format("Скорость: {0} Км/ч", value);
    }

    public void SetRpmValue(int value)
    {
        RpmLabel.text = String.Format("RPM: {0} Об/мин", value);
    }
}
