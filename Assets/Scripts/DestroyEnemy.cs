using UnityEngine;
using System.Collections;

public class DestroyEnemy : MonoBehaviour {

    public AudioSource explosion;
    public GameObject gM;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Boundary")
			return;
		if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Animator>().SetTrigger("die");
            
        }

        if (other.tag == "Nuke")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Animator>().SetTrigger("die");
        }
    }

    public void Die()
    {
        gM.GetComponent<GameManager>().changeScore(10);
        explosion.Play();
        Destroy(gameObject);
    }
}
