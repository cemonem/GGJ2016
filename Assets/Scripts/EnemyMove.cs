using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	public float speed;
	private Rigidbody2D rigi;
	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody2D> ();
		rigi.velocity = transform.up * (-1) * speed;
	}

}
