using UnityEngine;
using System.Collections;

public class SoulDestroyer : MonoBehaviour {

	public float doomIncrease;
	public GameObject gM;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D collider)
    {
			if (collider.tag == "HSoul" || collider.tag == "OSoul" || collider.tag == "CSoul") {
				gM.GetComponent<GameManager>().changeDoom(doomIncrease);
			}
            Destroy(collider.gameObject);
    }
}
