using UnityEngine;
using System.Collections;

public class bloom_color_cycle : MonoBehaviour {
	private GlowEffect eff;
	// Use this for initialization

	public Color[] colors;
	
	public int currentIndex = 0;
	private int nextIndex;
	
	public float changeColourTime = 2.0f;
	
	private float lastChange = 0.0f;
	private float timer = 0.0f;






	void Start () {
		eff = this.GetComponent<GlowEffect> ();

		if (colors == null || colors.Length < 2)
			Debug.Log ("Need to setup colors array in inspector");
		
		nextIndex = (currentIndex + 1) % colors.Length;    



	}
	
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;
		
		if (timer > changeColourTime) {
			currentIndex = (currentIndex + 1) % colors.Length;
			nextIndex = (currentIndex + 1) % colors.Length;
			timer = 0.0f;
			
		}

        if (!level_manager.is_in_menu)
        {
            eff.enabled = true;
            eff.glowTint = Color.Lerp(colors[currentIndex], colors[nextIndex], timer / changeColourTime);
        }
        else
        {
            eff.enabled = false;
            eff.glowTint = Color.white;
        }
	


	}
}
