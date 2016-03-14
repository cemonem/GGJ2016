using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public GameObject spawn;
	public GameObject beam;
	public float speed;
	public float fireRate;
	
	private float nextFire;
	private Transform trans,spawnTrans;
	bool shoot;
    // Use this for initialization
    public GameObject priestess;

	void Start () {
		trans = GetComponent<Transform>();
		spawnTrans = spawn.GetComponent<Transform> (); 
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetButtonDown("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject spawned;
			Vector2 line=new Vector2(trans.position.x-spawnTrans.position.x, trans.position.y-spawnTrans.position.y);
			line.Normalize();
			spawned = Instantiate(beam,new Vector3(spawnTrans.position.x,spawnTrans.position.y,0),Quaternion.identity) as GameObject;
            float angle = Mathf.Atan2(-line.x, line.y) * Mathf.Rad2Deg;
            spawned.GetComponent<Transform>().rotation=Quaternion.Euler(0,0, angle);
			spawned.GetComponent<Rigidbody2D>().velocity=line*speed;
            priestess.GetComponent<Animator>().SetTrigger("fire");
		}	
	
	}
}
