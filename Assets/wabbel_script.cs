using UnityEngine;
using System.Collections;

public class wabbel_script : MonoBehaviour {

	public float rady_min, rady_max, radx_min, radx_max;
	public bool toggle_rad_y, toggle_rad_x;
	public float rad_y_speed, rad_x_speed;



	public float centery_min, centery_max, centerx_min, centerx_max;
	public bool toggle_center_y, toggle_center_x;
	public float center_y_speed, center_x_speed;

	public bool active;
	private TwirlEffect eff;
	// Use this for initialization
	void Start () {

		eff = this.GetComponent<TwirlEffect> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (rady_min != rady_max && !level_manager.is_in_menu && active) {
						if (toggle_rad_y) {
								eff.radius.y += rad_y_speed * Time.deltaTime;
								if (eff.radius.y >= rady_max) {
										toggle_rad_y = false;
								}
						} else {
								eff.radius.y -= rad_y_speed * Time.deltaTime;
								if (eff.radius.y <= rady_min) {
										toggle_rad_y = true;
								}
						}
				}


		if (radx_min != radx_max && !level_manager.is_in_menu && active) {
			if (toggle_rad_x) {
				eff.radius.x += rad_x_speed * Time.deltaTime;
				if (eff.radius.x >= radx_max) {
					toggle_rad_x = false;
				}
			} else {
				eff.radius.x -= rad_x_speed * Time.deltaTime;
				if (eff.radius.x <= radx_min) {
					toggle_rad_x = true;
				}
			}
		}







		if (centerx_min != centerx_max && !level_manager.is_in_menu && active) {
			if (toggle_center_x) {
				eff.center.x += center_x_speed * Time.deltaTime;
				if (eff.center.x >= centerx_max) {
					toggle_center_x = false;
				}
			} else {
				eff.center.x -= center_x_speed * Time.deltaTime;
				if (eff.center.x <= centerx_min) {
					toggle_center_x = true;
				}
			}
		}


		if (centery_min != centery_max && !level_manager.is_in_menu && active) {
			if (toggle_center_y) {
				eff.center.y += center_y_speed * Time.deltaTime;
				if (eff.center.y >= centery_max) {
					toggle_center_y = false;
				}
			} else {
				eff.center.y -= center_y_speed * Time.deltaTime;
				if (eff.center.y <= centery_min) {
					toggle_center_y = true;
				}
			}
		}


		if (level_manager.is_in_menu || !active) {
			eff.radius.x = 0;
			eff.radius.y = 0;
			eff.center.x = 0;
			eff.center.y = 0;
		}



	}
}
