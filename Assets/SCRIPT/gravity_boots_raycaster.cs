/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class gravity_boots_raycaster : MonoBehaviour {

  public int ignore_layer;
  public bool enable_ignore;
  public Transform destination_cube;
  public string tagCheck;
  public bool enableTagcheck;
  public float minimum_distance;
  public bool active;
  public bool direction_right;
  public Color color;
  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {


  

    RaycastHit[] hits;
    RaycastHit hitUse = new RaycastHit();
    bool foundHit = false;
    if (enable_ignore)
    {
      hits = Physics.RaycastAll(this.transform.position, transform.up, ignore_layer);
    }
    else
    {
      hits = Physics.RaycastAll(this.transform.position, transform.forward);
    }

    float shortestDist;
    shortestDist = Mathf.Infinity;

    
    for (int i = 0; i < hits.Length; i++)
    {
        Debug.DrawLine(this.transform.position, hits[i].point, Color.cyan);

      if (enableTagcheck)
      {
        if (hits[i].transform.tag == tagCheck)
        {
          if (Vector3.Distance(this.transform.position, hits[i].point) < shortestDist)
          {

            hitUse = hits[i];
            shortestDist = Vector3.Distance(this.transform.position, hits[i].point);
            foundHit = true;
          }//ende vec3
        }//ende tag
      }
      else
      {

        if (Vector3.Distance(this.transform.position, hits[i].point) < shortestDist)
        {

          hitUse = hits[i];
          shortestDist = Vector3.Distance(this.transform.position, hits[i].point);
          foundHit = true;
        }//ende vec3


      }//ende enable

      if (shortestDist <= minimum_distance)
      {
        active = true;
      }
      else
      {
        active = false;
      }

    }

    if (foundHit)
    {

      destination_cube.transform.position = hitUse.point;




      destination_cube.rotation = Quaternion.LookRotation(hitUse.normal);




    }//ende found hit

  }//ende update
}
