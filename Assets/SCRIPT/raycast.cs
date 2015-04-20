/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class raycast : MonoBehaviour {

  public int ignore_layer;
  public bool enable_ignore;
	public Transform destination_cube;
	public GameObject beam_holder;
	public string tagCheck;
	public bool enableTagcheck;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		LineRenderer lr =	beam_holder.GetComponent<LineRenderer>();
				lr.SetPosition(0,this.transform.position);

		RaycastHit[] hits;
		RaycastHit hitUse = new RaycastHit ();
		bool foundHit = false;
    if (enable_ignore)
    {
      hits = Physics.RaycastAll(this.transform.position, transform.forward, ignore_layer);
    }
    else
    {
      hits = Physics.RaycastAll(this.transform.position, transform.forward);
    }
 
		float shortestDist;
		shortestDist = Mathf.Infinity;

		for (int i = 0; i < hits.Length; i++) {
			if(enableTagcheck){
			if(hits[i].transform.tag == tagCheck){
				if(Vector3.Distance(this.transform.position, hits[i].point) < shortestDist){

					hitUse = hits[i];
					shortestDist = Vector3.Distance(this.transform.position, hits[i].point);
					foundHit = true;
				}//ende vec3
			}//ende tag
			}else{

					if(Vector3.Distance(this.transform.position, hits[i].point) < shortestDist){
						
						hitUse = hits[i];
						shortestDist = Vector3.Distance(this.transform.position, hits[i].point);
						foundHit = true;
					}//ende vec3


			}//ende enable

		}

		if (foundHit) {

			destination_cube.transform.position = hitUse.point;



		lr.SetPosition(1,hitUse.point);
			destination_cube.rotation = Quaternion.LookRotation(hitUse.normal);



		
		}//ende found hit

	}//ende update
}
