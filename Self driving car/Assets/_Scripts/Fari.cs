using UnityEngine;
using System.Collections;

public class Fari : MonoBehaviour {
     public Light light1;
     public Light light2;
     public Light light3;
     public Light light4;
     public Light light5;
     public Light light6;
     
	// Use this for initialization
	void Start () {

        light1.enabled = false;
        light2.enabled = false;
               
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        bool brakeButton = Input.GetButton("Jump");
         if (Input.GetKeyDown("l"))
        
        {
            light1.enabled = true;
            light2.enabled = true;
   
        }
         if (Input.GetKeyDown("k"))
         {
             light1.enabled = false;
             light2.enabled = false;

         }
         if (brakeButton)
         {
             light3.intensity = 8;
             light4.intensity = 8;
             light5.intensity = 8;
             light6.intensity = 8;
         }
         else
         {
             light3.intensity = 1;
             light4.intensity = 1;
             light5.intensity = 1;
             light6.intensity = 1; 
         }
	}
}
