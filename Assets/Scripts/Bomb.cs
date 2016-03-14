using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
    public float detonateTime;
    public float maxScale;
    public float dur;
    public float rad;

    private float curTime;
    new private Transform transform;
    private Vector2 scaleVector;
    private bool growing = true;
	// Use this for initialization
	void Start() {
        GetComponent<CircleCollider2D>().radius = rad;
        transform = GetComponent<Transform>();
        scaleVector = new Vector2(maxScale, maxScale);
	}

    // Update is called once per frame
    void Update()
    {
        if (growing)
        {
            curTime += Time.deltaTime;
            if (curTime < detonateTime)
            {
                transform.localScale = Vector2.Lerp(Vector2.one, scaleVector, curTime / detonateTime);
            }
            else
            {
                curTime -= detonateTime;
                GetComponent<Animator>().SetTrigger("Bombi");
                growing = false;
            }
        }
    }

    public void startExploding()
    {
        growing = false;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    

    void OnTriggerStay2D(Collider2D collider)
    {
        if(!growing && collider.tag == "Enemy")
        {
            collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collider.GetComponent<Animator>().SetTrigger("die");
        }
    }
}
