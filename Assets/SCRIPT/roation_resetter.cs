/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */






using UnityEngine;
using System.Collections;

public class roation_resetter : MonoBehaviour
{


  public float x;
  public float y;
  public float z;


  public bool active;
  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (active)
    {
      this.transform.rotation = Quaternion.Euler(x, y, z);
   //   this.transform.localEulerAngles = new Vector3(add_rotaton.x, add_rotaton.y, add_rotaton.z);
    }
  }
}
