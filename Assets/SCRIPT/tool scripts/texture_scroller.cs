using UnityEngine;
using System.Collections;

public class texture_scroller : MonoBehaviour {
  public float scroll_speed;
  float offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
     offset += scroll_speed * Time.deltaTime;
    this.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
