using UnityEngine;
using System.Collections;

public class show_throws : MonoBehaviour {


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
  private int throws_left;

  public GameObject number_tens;
  public GameObject number_ones;


  public GameObject background_plane;

 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    throws_left = (int)level_manager.max_throws - (int)level_manager.throws;


    if (level_manager.is_in_menu)
    {
      number_ones.gameObject.SetActive(false);
      number_tens.gameObject.SetActive(false);
      background_plane.gameObject.SetActive(false);
    }
    else
    {
      number_ones.gameObject.SetActive(true);
      number_tens.gameObject.SetActive(true);
      background_plane.gameObject.SetActive(true);
    }


    level_nr_e = throws_left % 10;
    level_nr_z = (throws_left - level_nr_e) / 10;


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
