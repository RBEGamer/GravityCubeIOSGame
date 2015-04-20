using UnityEngine;
using System.Collections;

public class Pressure_plate : MonoBehaviour 
{
 
   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        this.GetComponent<Animation>().wrapMode = WrapMode.Once;
        this.GetComponent<Animation>().Play("Activate");
		GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().StopSound(AudioManager.AudioClipManaged.schalter, this.gameObject);
		//Camera.main.GetComponent<SoundManager>().PlaySounds(0);
        //idle = true;
    }
    void OnTriggerExit(Collider other)
    {
        this.GetComponent<Animation>().wrapMode = WrapMode.Once;
        this.GetComponent<Animation>().Play("Deactivate");
    }
}
