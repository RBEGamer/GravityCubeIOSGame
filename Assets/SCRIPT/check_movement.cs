/* Copyright (C) Team Newtons Aepfel- All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Marcel Ochsendorf <marcel.ochsendorf@gmail.com>,  
 */







using UnityEngine;
using System.Collections;

public class check_movement : MonoBehaviour
{
  //Set this to the transform you want to check
  public Transform objectTransfom;
  public float noMovementThreshold = 0.0001f;
  public const int noMovementFrames = 3;
  public Vector3[] previousLocations = new Vector3[noMovementFrames];
  public bool isMoving;
  public bool submit_to_level_manager;
  public float delta_time;
  public float max_time;
  //Let other scripts see if the object is moving
  public bool IsMoving
  {
    get { return isMoving; }
  }

  void Awake()
  {

    objectTransfom = this.transform;
    //For good measure, set the previous locations
    for (int i = 0; i < previousLocations.Length; i++)
    {
      previousLocations[i] = Vector3.zero;
    }
  }

  void Update()
  {


    //  if (objectTransfom.rigidbody.velocity.y == 0)
    //  {
    //    grounded = true;
    //  }
    //  else
    //  {
    //    grounded = false ;
    //  }

   


    //Store the newest vector at the end of the list of vectors
    for (int i = 0; i < previousLocations.Length - 1; i++)
    {
      previousLocations[i] = previousLocations[i + 1];
    }
    previousLocations[previousLocations.Length - 1] = objectTransfom.position;

    //Check the distances between the points in your previous locations
    //If for the past several updates, there are no movements smaller than the threshold,
    //you can most likely assume that the object is not moving
    for (int i = 0; i < previousLocations.Length - 1; i++)
    {
      if (Vector3.Distance(previousLocations[i], previousLocations[i + 1]) >= noMovementThreshold)
      {
        isMoving = true;
      }
      else
      {
        isMoving = false;
        break;
      }
    }

    delta_time += Time.deltaTime;
    if (delta_time >= max_time)
    {

      delta_time = 0;
        level_manager.is_any_cube_moving = isMoving;
      



    }

    if (isMoving)
    {
      level_manager.is_any_cube_moving = true;
    }



  }




}
