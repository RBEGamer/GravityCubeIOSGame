using UnityEngine;
using System.Collections;

public class slider : MonoBehaviour {
  public bool slider_functionallity;
    public bool x_axis;
    public bool y_axis;
  public GameObject slider_controller;
  public GameObject slider_collider;
  public GameObject slider_object;
	// Use this for initialization
	void Start () {

    slider_collider.gameObject.SetActive(false);

   // this.rigidbody.constraints = RigidbodyConstraints.None;

     //this.rigidbody.freezeRotation = true;
     //this.rigidbody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
     //rigidbody.constraints &= RigidbodyConstraints.FreezePositionY;
	}
	
	// Update is called once per frame
	void Update () {


    if (slider_functionallity && !level_manager.is_level_rotating) {
      /*
      if (axis_selection)
      {
        if (level_manager.level_orientation == 1 || level_manager.level_orientation == 3)
        {
          slider_controller.gameObject.SetActive(false);
          slider_collider.gameObject.SetActive(true);
        }
        else
        {
          slider_controller.gameObject.SetActive(true);
          slider_collider.gameObject.SetActive(false);
        }
      }
      else
      {
        if (level_manager.level_orientation == 0 || level_manager.level_orientation == 2)
        {
        slider_controller.gameObject.SetActive(true);
        slider_collider.gameObject.SetActive(false);
        }
        else
        {
        slider_controller.gameObject.SetActive(false);
        slider_collider.gameObject.SetActive(true);
        }
      }

      */
      
      if (y_axis)
      {
        if (level_manager.level_orientation == 1 || level_manager.level_orientation == 3)
        {
          slider_controller.gameObject.SetActive(false);
          slider_collider.gameObject.SetActive(true);
        }
        else
        {
          slider_controller.gameObject.SetActive(true);
          slider_collider.gameObject.SetActive(false);
        }

      }


      if (x_axis)
      {
        if (level_manager.level_orientation == 0 || level_manager.level_orientation == 2)
        {
          slider_controller.gameObject.SetActive(false);
          slider_collider.gameObject.SetActive(true);
        }
        else
        {
          slider_controller.gameObject.SetActive(true);
          slider_collider.gameObject.SetActive(false);
        }

      }

      
/*
    switch (level_manager.level_orientation)
    {
      case 1:
        if (!axis_selection)
        {
          slider_controller.rigidbody.AddForce(new Vector3(0, Physics.gravity.y, 0), ForceMode.Acceleration);
        }
        else
        {
          slider_controller.rigidbody.AddForce(new Vector3(Physics.gravity.y, 0, 0), ForceMode.Acceleration);
        }
      break;

      case 0:
      if (!axis_selection)
      {
        slider_controller.rigidbody.AddForce(new Vector3(Physics.gravity.y, 0, 0), ForceMode.Acceleration);
      }
      else
      {
        slider_controller.rigidbody.AddForce(new Vector3(0, -Physics.gravity.y, 0), ForceMode.Acceleration);
      }
      
      break;

      case 3:
      if (!axis_selection)
      {
        slider_controller.rigidbody.AddForce(new Vector3(0, Physics.gravity.y, 0), ForceMode.Acceleration);
      }
      else
      {
        slider_controller.rigidbody.AddForce(new Vector3(Physics.gravity.y, 0, 0), ForceMode.Acceleration);
      }
      break;

      case 2:
      if (!axis_selection)
      {
        slider_controller.rigidbody.AddForce(new Vector3(Physics.gravity.y, 0, 0), ForceMode.Acceleration);
      }
      else
      {
        slider_controller.rigidbody.AddForce(new Vector3(0, -Physics.gravity.y, 0), ForceMode.Acceleration);
      }
      break;


      default:
      
      break;
    }//ende switch
      */





      if (level_manager.level_orientation == 0)
      {


 
        if (y_axis)
        {
          slider_controller.GetComponent<Rigidbody>().AddForce(new Vector3(-Physics.gravity.y, 0, 0), ForceMode.Acceleration);
        }



      }


      if (level_manager.level_orientation == 1)
      {
        if (x_axis)
        {
          slider_controller.GetComponent<Rigidbody>().AddForce(new Vector3(Physics.gravity.y, 0, 0), ForceMode.Acceleration);
        }
      }

      if (level_manager.level_orientation == 3)
      {
        if (x_axis)
        {
          slider_controller.GetComponent<Rigidbody>().AddForce(new Vector3(Physics.gravity.y, 0, 0), ForceMode.Acceleration);
        }

       
      }



      if (level_manager.level_orientation == 2)
      {


        

        if (y_axis)
        {
          slider_controller.GetComponent<Rigidbody>().AddForce(new Vector3(-Physics.gravity.y, 0, 0), ForceMode.Acceleration);
        }



      }


    }else{
      slider_controller.gameObject.SetActive(true);
      slider_collider.gameObject.SetActive(false);
    }
    }//ende slider func
	}

