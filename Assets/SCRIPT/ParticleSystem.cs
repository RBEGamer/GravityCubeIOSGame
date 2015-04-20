
using UnityEngine;
using System.Collections;

public class ParticleSystem : MonoBehaviour 
{
  
  public GameObject partsys;
  public Transform direction;
	// Use this for initialization
	void Start () 
  {
    //partsys = this.partsys.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () 
  {
    this.transform.position = partsys.transform.position;
    //partsys.particleEmitter.angularVelocity = direction.

    partsys.transform.forward = Vector3.Normalize(direction.position - partsys.transform.position);

    
	}
}
