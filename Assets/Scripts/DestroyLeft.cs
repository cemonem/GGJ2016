using UnityEngine;
using System.Collections;

public class DestroyLeft : MonoBehaviour
{
	public GameObject gM;
	public float damage;

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Enemy") {
			gM.GetComponent<GameManager>().changeDoom(damage);
		}
		Destroy(other.gameObject);
	}
}