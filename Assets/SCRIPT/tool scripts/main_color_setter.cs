using UnityEngine;
using System.Collections;

public class main_color_setter : MonoBehaviour {
  public float r;
  public float g;
  public float b;
  public float a;
  
  public GameObject colors_holder;
  private colors colors_holder_script;
  public bool is_particlesystem;
  public bool is_light;
  private ParticleSystem ps;
	// Use this for initialization
	void Start () {
 //   material.color = Color32(rgb.x, rgb, y, rgb.z, 1);
   // this.renderer.material.SetColor("_Color", new Color(r/255, g/255, b/255, a/255));
	}
	
	// Update is called once per frame
	void Update () {

    colors_holder_script = colors_holder.GetComponent<colors>();
   this.r =  colors_holder_script.r;
   this.g = colors_holder_script.g;
   this.b = colors_holder_script.b;
   this.a = colors_holder_script.a;
    
   if (is_particlesystem)
   {
    // ps = this.GetComponent<ParticleSystem>();
    // ps.particleSystem.startColor = new Color(r / 255, g / 255, b / 255, a / 255);
    // this.particleSystem.startColor = new Color(r / 255, g / 255, b / 255, a / 255);
			//this.GetComponent<ParticleSystem>().particleSystem.startColor =  new Color(r / 255, g / 255, b / 255, a / 255);
			this.GetComponent<UnityEngine.ParticleSystem>().startColor =  new Color(r / 255, g / 255, b / 255, a / 255);

   }
   else if (is_light)
   {

      this.GetComponent<Light>().color = new Color(r / 255, g / 255, b / 255, a / 255);

   }
   else
   {
     this.GetComponent<Renderer>().material.SetColor("_Color", new Color(r / 255, g / 255, b / 255, a / 255));
   }



   

	}
}
