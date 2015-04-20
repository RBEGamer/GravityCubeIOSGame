using UnityEngine;
using System.Collections;

public class Pressure_plateanimation : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void OnCollisionStay (Collision other)
    {
        this.GetComponent<Animation>().wrapMode = WrapMode.Once;
        this.GetComponent<Animation>().Play("Activate");
        //idle = true;
    }
}
