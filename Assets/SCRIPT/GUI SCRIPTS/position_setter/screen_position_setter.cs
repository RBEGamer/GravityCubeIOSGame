using UnityEngine;
using System.Collections;

public class screen_position_setter : MonoBehaviour
{




  public Vector3 pos;

  void Update()
  {

  //  Vector3 screensize = Camera.main.ScreenToWorldPoint(Screen.width - 10, Screen.height - 10,12.0f);
   // this.transform.position = pos;
    this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0) + pos);
  }
}


