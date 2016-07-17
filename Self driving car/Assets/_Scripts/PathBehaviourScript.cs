using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class PathBehaviourScript : MonoBehaviour {
    public GameObject PointPrefab;
    public GameObject[] PathProviderPrefabs;
    public Button Track1;
    public Button Track2;
    public GameObject Panel;
    private GameObject _currentPoint;
    private int _currentIndex;
    private List<Vector3> _pointList;
    private PathProviderScript pathProvider;
    protected PanelInfoScript _panelInfoScript;

    // Use this for initialization
    void Start () {
        _currentIndex = -1;
        Track1.onClick.AddListener(Track1OnClick);
        Track2.onClick.AddListener(Track2OnClick);
        _panelInfoScript = GameObject.Find("Info_panel").GetComponent<PanelInfoScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if (_currentPoint == null)
            return;

        if (!isPathProviderExist())
            return;

        var pathPointBehaviourScript = (PathPointBehaviourScript)_currentPoint.GetComponent<PathPointBehaviourScript>();

        if (pathPointBehaviourScript.IsTriggered)
            AddNextPoint();
    }

    void AddNextPoint()
    {
        _currentIndex++;
        if (_currentIndex > pathProvider.Count() - 1)
        {
            _currentIndex = -1;
            pathProvider = null;
            Panel.SetActive(true);
            LogEndPath();
            return;
        }

        Destroy(_currentPoint);
        _currentPoint = (GameObject)Instantiate(PointPrefab, pathProvider.GetPoint(_currentIndex).position, transform.rotation);
    }

    public Vector3 GetCurrentPoint()
    {
        return _currentPoint.transform.position;
    }

    public bool isPathProviderExist()
    {
        return pathProvider != null;
    }

    void Track1OnClick()
    {
        pathProvider = PathProviderPrefabs[0].GetComponent<PathProviderScript>();
        Panel.SetActive(false);
        AddNextPoint();
        LogStartPath(1);
    }

    void Track2OnClick()
    {
        pathProvider = PathProviderPrefabs[1].GetComponent<PathProviderScript>();
        Panel.SetActive(false);
        AddNextPoint();
        LogStartPath(2);
    }

    void LogStartPath(int number)
    {
        if(_panelInfoScript != null)
            _panelInfoScript.AddDecisionLogRecord(String.Format("Начинаю движение по маршруту №{0}", number));
    }

    void LogEndPath()
    {
        if (_panelInfoScript != null)
            _panelInfoScript.AddDecisionLogRecord("Конец маршрута");
    }
}
