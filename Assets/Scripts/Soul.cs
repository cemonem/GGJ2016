using UnityEngine;
using System.Collections;

public class Soul : MonoBehaviour {

    public float wiggle;
    public float wiggleSpeed;
    public bool touched = false;
    private float originalY;
    new private Transform transform;
	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x,transform.position.y+wiggleSpeed);
        if(transform.position.y > originalY + wiggle || transform.position.y < originalY - wiggle)
        {
            wiggleSpeed = -wiggleSpeed;
        }
        
    }
}