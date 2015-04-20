using UnityEngine;
using System.Collections;

public class player_cube_mover : MonoBehaviour {





    public float min;
   public  bool is_r_right = false;
    public bool is_l_right = false;


    public string[] to_switch_tags = new string[10];

    public float min_port_distance_to_player;
    public bool auto_calc_port_distance;
    private bool clicked;
    private Vector2 userTouch;
    public int raycast_range = 100;
    private Vector2 userMouse;
    public float port_offset_r;
    public float port_offset_l;
    public bool is_wall_left;
    public bool is_wall_right;
    public float r_distnce_to_next_object;
    public float l_distnce_to_next_object;

    // Use this for initialization
    void Start () {
        if (auto_calc_port_distance)
        {
            min_port_distance_to_player = this.transform.localScale.x / 2 + 0.02f;
        }
	}
	
	// Update is called once per frame
	void Update () {


 is_r_right = false;
 is_l_right = false;






        //check wall


    RaycastHit hit_r;
        if (Physics.Raycast(transform.position, Vector3.right, out hit_r))
            // float distanceToGround = hit.distance;
            r_distnce_to_next_object = hit_r.distance;

        if (hit_r.distance <= min)
            {
            //stop_right = true;
            r_distnce_to_next_object =  hit_r.distance;
                foreach (string tag in to_switch_tags) //the line the error is pointing to
                {
                    if (hit_r.collider.gameObject.tag == tag && hit_r.collider.gameObject.tag != "")
                    {
                        is_r_right = true;
                    }
                }


            }
            else
            {
                //stop_right = false;
            }

  


       // Debug.Log("R  : " + hit_r.distance + "   is_right  :  " + is_r_right);

        RaycastHit hit_l;
        if (Physics.Raycast(transform.position, -Vector3.right, out hit_l))
            // float distanceToGround = hit.distance;
            l_distnce_to_next_object = hit_l.distance;
        if (hit_l.distance <= min)
            {
                

                foreach (string tag in to_switch_tags) //the line the error is pointing to
                {
                    if (hit_l.collider.gameObject.tag == tag && hit_l.collider.gameObject.tag != "")
                    {
                        is_l_right = true;
                    }
                }


            }
            else
            {
                //stop_left = false;
            }
        // Debug.Log("L  : " + hit_l.distance + "   is_left  :  " + is_l_right);








     //   Debug.Log("R : " + r_distnce_to_next_object);




        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            //we are on a desktop device, so don't use touch
            if (Input.GetButtonDown("Fire1") && !level_manager.is_level_failed)
            {
           
                userMouse = Input.mousePosition;
                Ray userTouchRayM = Camera.main.ScreenPointToRay(userMouse);
                RaycastHit raycast_infoM;
        
                if (Physics.Raycast(userTouchRayM, out raycast_infoM, raycast_range))
                {
                  //  Debug.Log(raycast_infoM.collider.gameObject);

                    if (raycast_infoM.collider.gameObject == this.gameObject) {
                     //   Debug.Log("qwe");
                        if (is_l_right && is_wall_right)
                        {
                            Vector3 old_pos = hit_l.collider.gameObject.transform.position;
                            GameObject hit_obj = hit_l.collider.gameObject;
                            float new_port_distance = 0.0f ;
                            if(hit_l.distance * 2 < min_port_distance_to_player){ new_port_distance = min_port_distance_to_player;
                            }else{new_port_distance =  hit_l.distance * 2;}

                            if(r_distnce_to_next_object > new_port_distance + port_offset_l)
                            {
                                hit_l.transform.position = new Vector3(old_pos.x + new_port_distance + port_offset_l, old_pos.y, old_pos.z);
                            }
                        }
                        else if (is_r_right && is_wall_left)
                        {
                            Vector3 old_pos = hit_r.collider.gameObject.transform.position;
                            GameObject hit_obj = hit_r.collider.gameObject;
                            float new_port_distance = 0.0f;

                            if (hit_r.distance*2 <= min_port_distance_to_player){
                                new_port_distance = min_port_distance_to_player;
                            }else{
                                new_port_distance = hit_r.distance * 2;
                            }
                            if (l_distnce_to_next_object  >= new_port_distance + port_offset_r){
                                hit_r.transform.position = new Vector3(old_pos.x - new_port_distance - port_offset_r, old_pos.y, old_pos.z);
                            }
                        }



                    }


                }
            }
        }
        //if it isn't a desktop, lets see if our device is a handheld device aka a mobile device
        else if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            //we are on a mobile device, so lets use touch input
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                userTouch = Input.GetTouch(0).position;
                Ray userTouchRay = Camera.main.ScreenPointToRay(userTouch);
                RaycastHit raycast_info;
                if (Physics.Raycast(userTouchRay, out raycast_info, raycast_range))
                {
                    if (raycast_info.collider.gameObject == this) {
                        if (is_l_right && is_wall_right)
                        {
                            Vector3 old_pos = hit_l.collider.gameObject.transform.position;
                            GameObject hit_obj = hit_l.collider.gameObject;
                            float new_port_distance = 0.0f;
                            if (hit_l.distance * 2 < min_port_distance_to_player)
                            {
                                new_port_distance = min_port_distance_to_player;
                            }
                            else { new_port_distance = hit_l.distance * 2; }

                            if (r_distnce_to_next_object > new_port_distance + port_offset_l)
                            {
                                hit_l.transform.position = new Vector3(old_pos.x + new_port_distance + port_offset_l, old_pos.y, old_pos.z);
                            }
                        }
                        else if (is_r_right && is_wall_left)
                        {
                            Vector3 old_pos = hit_r.collider.gameObject.transform.position;
                            GameObject hit_obj = hit_r.collider.gameObject;
                            float new_port_distance = 0.0f;

                            if (hit_r.distance * 2 <= min_port_distance_to_player)
                            {
                                new_port_distance = min_port_distance_to_player;
                            }
                            else
                            {
                                new_port_distance = hit_r.distance * 2;
                            }
                            if (l_distnce_to_next_object >= new_port_distance + port_offset_r)
                            {
                                hit_r.transform.position = new Vector3(old_pos.x - new_port_distance - port_offset_r, old_pos.y, old_pos.z);
                            }
                        }
                    }
                }
            }
        }










    }
}
