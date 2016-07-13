using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour {

    public GameObject UserControlCar;
    public GameObject SimpleAICar;
    public Button SelectUserControlCar;
    public Button SelectSimpleAICar;

    private static GameObject _SelectedPrefab; 

	// Use this for initialization
	void Start () {
        if (_SelectedPrefab != null)
            Instantiate(_SelectedPrefab);

        if (SelectUserControlCar != null && SelectSimpleAICar)
        {
            SelectUserControlCar.onClick.AddListener(UserControlCarOnClick);
            SelectSimpleAICar.onClick.AddListener(SimpleAICarOnClick);
        }
    }
	
	// Update is called once per frame
	void Update () {
        	
	}

    void UserControlCarOnClick() {
        _SelectedPrefab = UserControlCar;
        SceneManager.LoadScene("Day(wheelcollider)");
    }

    void SimpleAICarOnClick() {
        _SelectedPrefab = SimpleAICar;
        SceneManager.LoadScene("Day(wheelcollider)");
    }
}
