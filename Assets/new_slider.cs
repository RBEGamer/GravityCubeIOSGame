using UnityEngine;
using System.Collections;

public class new_slider : MonoBehaviour
{








    public float stop_distance_right;
    public float stop_distance_left;
    public float stop_distance_up;
    public float stop_distance_down;
    public bool stop_right;
    public bool stop_left;
    public bool stop_up;
    public bool stop_down;

    public float speed;
    public bool is_x_slider_left;



	public bool rotate;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		rotate = GameObject.Find ("level").GetComponent<fucking_rotation_shit> ().shouldRotate;






        RaycastHit hit_r;
        if (Physics.Raycast(transform.position, Vector3.right, out hit_r))
           // float distanceToGround = hit.distance;

        if(hit_r.distance <= stop_distance_right)
        {
            stop_right = true;  
        }
        else
        {
            stop_right = false ;
        }







        RaycastHit hit_l;
        if (Physics.Raycast(transform.position, Vector3.right, out hit_l))
            // float distanceToGround = hit.distance;

            if (hit_l.distance <= stop_distance_left)
            {
                stop_left = true;
            }
            else
            {
                stop_left = false;
            }




        RaycastHit hit_u;
        if (Physics.Raycast(transform.position, Vector3.up, out hit_u))
           // float distanceToGround = hit.distance;

        if(hit_u.distance <= stop_distance_up)
        {
            stop_up = true;  
        }
        else
        {
            stop_up = false ;
        }
        Debug.DrawLine(this.transform.position, hit_u.point, Color.red);

       
        RaycastHit hit_d;
        if (Physics.Raycast(this.transform.position, Vector3.up, out hit_d))
            // float distanceToGround = hit.distance;

            if (hit_d.distance <= stop_distance_down)
            {
                stop_down = true;
            }
            else
            {
                stop_down = false;
            }

    //    Debug.Log(hit_d.distance);



		if (!stop_right && level_manager.level_orientation == 0 && !rotate && is_x_slider_left)
        {
          this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        }



		if ( !stop_left && level_manager.level_orientation == 2 && !rotate && is_x_slider_left)
        {
          this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        }






     

        if (!stop_up && level_manager.level_orientation == 0 && !rotate && !is_x_slider_left)
        {
          this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed * Time.deltaTime, this.transform.position.z);
        }



        if (!stop_down && level_manager.level_orientation == 2 && !rotate && !is_x_slider_left)
        {
          this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed * Time.deltaTime, this.transform.position.z);
        }
 
    }

}








