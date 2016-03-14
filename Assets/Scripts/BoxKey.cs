using UnityEngine;
using System.Collections;

public class BoxKey : MonoBehaviour {

    public TextMesh text;
    public KeyCode key;
	public GameObject gM;
	public float point;
    public int puanpuan;
    public AudioSource winAudio, loseAudio;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnKeyChanged(KeyCode key)
    {
        this.key = key;
        text.text = key.ToString();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bomb") return;
		Debug.Log (collider.tag + " " + tag);
        if (collider.tag == this.gameObject.tag) {
			Win ();
		}
        else Lose();
        Destroy(collider.gameObject);
    }

    void Lose()
    {
		gM.GetComponent<GameManager>().changeDoom(point);
        loseAudio.Play();
    }

    void Win()
    {
		gM.GetComponent<GameManager>().changeDoom(-point);
        gM.GetComponent<GameManager>().changeScore(puanpuan);
        winAudio.Play();
    }
}
