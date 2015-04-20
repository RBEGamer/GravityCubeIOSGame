using UnityEngine;
using System.Collections;

public class show_level : MonoBehaviour
{



  public string info = "HIER NUMBERS MATERIALS";
  public Material numbers_leer;
  public Material number_0;
  public Material number_1;
  public Material number_2;
  public Material number_3;
  public Material number_4;
  public Material number_5;
  public Material number_6;
  public Material number_7;
  public Material number_8;
  public Material number_9;

  int level_nr_e = 0, level_nr_z = 0;
  private int level;

  public GameObject number_tens;
  public GameObject number_ones;


	public bool is_inverted;
	public bool is_up_position;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

    level = game_manager.current_level+1;

		if (is_up_position) {
			if (level_manager.level_orientation == 2) {
				is_inverted = true;
			} else {
				is_inverted = false;
			}				
		
				} else {
			if (level_manager.level_orientation == 0) {
				is_inverted = true;
			} else {
				is_inverted = false;
			}	
		
		}



    level_nr_e = level % 10;
    level_nr_z = (level - level_nr_e) / 10;

				if (is_inverted) {
						level_nr_z = level % 10;
						level_nr_e = (level - level_nr_z) / 10;		
				} else {
					level_nr_e = level % 10;
					level_nr_z = (level - level_nr_e) / 10;		
		}

    switch (level_nr_e)
    {
      case 0: number_ones.transform.GetComponent<Renderer>().material = number_0; break;
      case 1: number_ones.transform.GetComponent<Renderer>().material = number_1; break;
      case 2: number_ones.transform.GetComponent<Renderer>().material = number_2; break;
      case 3: number_ones.transform.GetComponent<Renderer>().material = number_3; break;
      case 4: number_ones.transform.GetComponent<Renderer>().material = number_4; break;
      case 5: number_ones.transform.GetComponent<Renderer>().material = number_5; break;
      case 6: number_ones.transform.GetComponent<Renderer>().material = number_6; break;
      case 7: number_ones.transform.GetComponent<Renderer>().material = number_7; break;
      case 8: number_ones.transform.GetComponent<Renderer>().material = number_8; break;
      case 9: number_ones.transform.GetComponent<Renderer>().material = number_9; break;
      default:
        break;
    }

    switch (level_nr_z)
    {
      case 0: number_tens.transform.GetComponent<Renderer>().material = number_0; break;
      case 1: number_tens.transform.GetComponent<Renderer>().material = number_1; break;
      case 2: number_tens.transform.GetComponent<Renderer>().material = number_2; break;
      case 3: number_tens.transform.GetComponent<Renderer>().material = number_3; break;
      case 4: number_tens.transform.GetComponent<Renderer>().material = number_4; break;
      case 5: number_tens.transform.GetComponent<Renderer>().material = number_5; break;
      case 6: number_tens.transform.GetComponent<Renderer>().material = number_6; break;
      case 7: number_tens.transform.GetComponent<Renderer>().material = number_7; break;
      case 8: number_tens.transform.GetComponent<Renderer>().material = number_8; break;
      case 9: number_tens.transform.GetComponent<Renderer>().material = number_9; break;
      default:
        break;
    }


  }
}