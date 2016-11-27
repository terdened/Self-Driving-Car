using UnityEngine;
using System.Collections;

public class LightControlScript : MonoBehaviour {
    public int StartState = 1;
    public GameObject Red;
    public GameObject Yellow;
    public GameObject Green;

    private int _state;
    private int _counter;

    // Use this for initialization
    void Start () {
        if(StartState == 1)
            ActiveRed();
        if (StartState == 2)
            ActiveGreen();
    }
	
	// Update is called once per frame
	void Update () {
        switch(_state)
        {
            case 1:
                _counter++;
                if(_counter > 1000)
                {
                    ActiveYellow();
                }
                return;
            case 2:
                _counter++;
                if (_counter > 180)
                {
                    ActiveGreen();
                }
                return;
            case 3:
                _counter++;
                if (_counter > 1000)
                {
                    ActiveYellow1();
                }
                return;
            case 4:
                _counter++;
                if (_counter > 180)
                {
                    ActiveRed();
                }
                return;
            default:
                return;
        }
	}

    public int GetState()
    {
        return _state;
    }

    private void ActiveRed()
    {
        _state = 1;
        _counter = 1;
        Red.GetComponent<Light>().intensity = 8;
        Yellow.GetComponent<Light>().intensity = 0;
        Green.GetComponent<Light>().intensity = 0;
    }

    private void ActiveYellow()
    {
        _state = 2;
        _counter = 1;
        Red.GetComponent<Light>().intensity = 0;
        Yellow.GetComponent<Light>().intensity = 8;
        Green.GetComponent<Light>().intensity = 0;
    }

    private void ActiveGreen()
    {
        _state = 3;
        _counter = 1;
        Red.GetComponent<Light>().intensity = 0;
        Yellow.GetComponent<Light>().intensity = 0;
        Green.GetComponent<Light>().intensity = 8;
    }

    private void ActiveYellow1()
    {
        _state = 4;
        _counter = 1;
        Red.GetComponent<Light>().intensity = 0;
        Yellow.GetComponent<Light>().intensity = 8;
        Green.GetComponent<Light>().intensity = 0;
    }
}
