using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

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

    // Use this for initialization
    void Start () {
        _currentIndex = -1;
        Track1.onClick.AddListener(Track1OnClick);
        Track2.onClick.AddListener(Track2OnClick);
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
    }

    void Track2OnClick()
    {
        pathProvider = PathProviderPrefabs[1].GetComponent<PathProviderScript>();
        Panel.SetActive(false);
        AddNextPoint();
    }

}
