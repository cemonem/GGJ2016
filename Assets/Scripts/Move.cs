using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	Transform trans;
	public float xMin, xMax, yMin, yMax;
	public Camera cam;
	// Use this for initialization
	void Start () {
		trans=GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousepos = cam.ScreenToWorldPoint (Input.mousePosition);

		Vector2 mouse =  new Vector2 (
			Mathf.Clamp (mousepos.x, xMin, xMax),
			Mathf.Clamp (mousepos.y, yMin, yMax)
			);
		trans.position = mouse;
	}
}
