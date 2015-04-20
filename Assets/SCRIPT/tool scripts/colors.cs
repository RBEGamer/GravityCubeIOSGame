using UnityEngine;
using System.Collections;

public class colors : MonoBehaviour {

  public enum ColorTemplate
  {
    red, green, blue, yellow, rosa,white, black, orange, porn, brown
  }

  public float r;
  public float g;
  public float b;
  public float a;
  public ColorTemplate color_template;
  public ColorTemplate selected_color;
	// Use this for initialization
	void Start () {
    get_color();
	}
	
	// Update is called once per frame
	void Update () {
    get_color();
	}


  void get_color()
  {


    selected_color = color_template;

    switch (color_template)
    {
      case ColorTemplate.red:
        r = 255;g = 0; b = 0; a = 0;
        break;
      case ColorTemplate.green:
        r = 3;g = 250; b = 8; a = 0;
        break;
      case ColorTemplate.blue:
        r = 0;g = 182; b = 241; a = 0;
        break;
      case ColorTemplate.yellow:
        r = 240;g = 255; b = 0; a = 0;
        break;
      case ColorTemplate.rosa:
        r = 206;g = 4; b = 219; a = 0;
        break;
      case ColorTemplate.white:
        r = 245;g = 245; b = 245; a = 0;
        break;
      case ColorTemplate.black:
        r = 39;g = 39; b = 39; a = 0;
        break;
      case ColorTemplate.orange:
        r = 255;g = 115; b = 0; a = 0;
			break;
		case ColorTemplate.brown:
			r = 102;g = 51; b = 45; a = 0;
        break;
      default:
        break;
    }
  }
}
