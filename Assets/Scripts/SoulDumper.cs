using UnityEngine;
using System.Collections;

public class SoulDumper : MonoBehaviour {

    public GameObject[] boxes;
    public float dumpSpeed;
    private Vector2 speedVec;
	public GameObject gM;
    public bool pass = false;

	// Use this for initialization
	void Start () {
        speedVec = new Vector2(dumpSpeed, dumpSpeed);
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "HSoul" || collider.tag == "OSoul" || collider.tag == "CSoul")
        {
            if (collider.gameObject.GetComponent<Soul>().touched) return;
            Vector2 position = collider.gameObject.GetComponent<Transform>().position;
            Rigidbody2D rigidbody = collider.gameObject.GetComponent<Rigidbody2D>();
            if (pass)
            {
                if (collider.tag == "HSoul")
                {
                    collider.gameObject.GetComponent<Soul>().touched = true;
                    Vector2 boxPosition = boxes[0].GetComponent<Transform>().position;
                    Vector2 vel = new Vector2(boxPosition.x - position.x, boxPosition.y - position.y);
                    vel.Normalize();
                    vel.Scale(speedVec);
                    rigidbody.velocity = vel;
                    GetComponentInParent<Animator>().SetTrigger("push");
                }
                else if (collider.tag == "OSoul")
                {
                    collider.gameObject.GetComponent<Soul>().touched = true;
                    Vector2 boxPosition = boxes[1].GetComponent<Transform>().position;
                    Vector2 vel = new Vector2(boxPosition.x - position.x, boxPosition.y - position.y);
                    vel.Normalize();
                    vel.Scale(speedVec);
                    rigidbody.velocity = vel;
                    GetComponentInParent<Animator>().SetTrigger("push");
                }
                else if (collider.tag == "CSoul")
                {
                    collider.gameObject.GetComponent<Soul>().touched = true;
                    Vector2 boxPosition = boxes[2].GetComponent<Transform>().position;
                    Vector2 vel = new Vector2(boxPosition.x - position.x, boxPosition.y - position.y);
                    vel.Normalize();
                    vel.Scale(speedVec);
                    rigidbody.velocity = vel;
                    GetComponentInParent<Animator>().SetTrigger("push");

                }
            }
            else if (Input.GetKeyDown(boxes[0].GetComponent<BoxKey>().key))
            {
                collider.gameObject.GetComponent<Soul>().touched = true;
                Vector2 boxPosition = boxes[0].GetComponent<Transform>().position;
                Vector2 vel = new Vector2(boxPosition.x - position.x, boxPosition.y - position.y);
                vel.Normalize();
                vel.Scale(speedVec);
                rigidbody.velocity = vel;
                GetComponentInParent<Animator>().SetTrigger("push");
            }
            else if (Input.GetKeyDown(boxes[1].GetComponent<BoxKey>().key))
            {
                collider.gameObject.GetComponent<Soul>().touched = true;
                Vector2 boxPosition = boxes[1].GetComponent<Transform>().position;
                Vector2 vel = new Vector2(boxPosition.x - position.x, boxPosition.y - position.y);
                vel.Normalize();
                vel.Scale(speedVec);
                rigidbody.velocity = vel;
                GetComponentInParent<Animator>().SetTrigger("push");
            }
            else if (Input.GetKeyDown(boxes[2].GetComponent<BoxKey>().key))
            {
                collider.gameObject.GetComponent<Soul>().touched = true;
                Vector2 boxPosition = boxes[2].GetComponent<Transform>().position;
                Vector2 vel = new Vector2(boxPosition.x - position.x, boxPosition.y - position.y);
                vel.Normalize();
                vel.Scale(speedVec);
                rigidbody.velocity = vel;
                GetComponentInParent<Animator>().SetTrigger("push");
            }
        }
		else if((collider.tag == "Nuke" || collider.tag == "Bomb"  || collider.tag == "Auto") && (Input.GetKeyDown(KeyCode.Space)))
        {
                
                gM.GetComponent<GameManager>().setPowerUp(collider.tag);
                Destroy(collider.gameObject);
        }
    }
}
