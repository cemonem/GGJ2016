using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Slider slider ;
	public GameObject nuke;
	public GameObject soulDumper;
    public GameObject bomb;
    public GameObject crosshair;
    public GameObject spawnPoint;
    public GameObject soulEmitter;
    public GameObject gameOverCanvas;
    public GameObject scoreText;
    public float nukeSpeed;
	public float startTime, waveTime, waitTime;
	public GameObject enemies;
	public int waveEnemyNumber;
	public Vector2 spawnPositions;
	private float doom=50;
	public float nextDoomIncrease,rateDoom,increaseValue;
    public GameObject powerUpLocation;
	private string powerUpName="";
	public Sprite[] powerUps;
	private bool powerUp;
    private int score = 0;
    public float maasgunu;
    public int maas;

    public AudioSource EnemyExplosm;


    private float curTime = 0;



    private bool gameover = false;
    public IEnumerator CR_GibmePuan()
    {
        while(!gameover)
        {
            changeScore(maas);
            yield return new WaitForSeconds(maasgunu);
        }
    }

	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn ());
        StartCoroutine(CR_GibmePuan());
		powerUp = false;
	}
	public float getDoom()
	{
		return doom;
	}
	public void changeDoom(float value)
	{
		doom += value;
		if (doom < 50)
			doom = 50;
        if (doom > 1000) 
            GameOver();
	}
    public void changeScore(int score)
    {
        if (!gameover)
        {
            this.score += score;
            scoreText.GetComponent<Text>().text = this.score.ToString();
        }
    }
    IEnumerator handleAuto()
    {
        soulDumper.GetComponent<SoulDumper>().pass = true;
        yield return new WaitForSeconds(10);
        soulDumper.GetComponent<SoulDumper>().pass = false;
    }
	// Update is called once per frame
	void Update () {
        curTime += Time.deltaTime;
        if(curTime > rateDoom)
        {
            curTime -= rateDoom;
            changeDoom(increaseValue);
        }
		if (Input.GetButtonDown ("Fire2") && powerUp) 
		{
			if(powerUpName=="Nuke")
			{
				GameObject spawned;
				Vector2 line=new Vector2(0f,1f);
				spawned = Instantiate(nuke,new Vector3(0,-1.49f,0),Quaternion.identity) as GameObject;
				spawned.GetComponent<Rigidbody2D>().velocity=line*nukeSpeed;
                spawnPoint.GetComponent<Animator>().SetTrigger("fire");
            }
            else if(powerUpName=="Bomb")
            {
               GameObject bombi = Instantiate(bomb, crosshair.GetComponent<Transform>().position, Quaternion.identity) as GameObject;
               bombi.GetComponent<Bomb>().enabled = true;
            }
            else if(powerUpName=="Auto")
            {
                StartCoroutine(handleAuto());
            }
			powerUpName="";
			powerUp=false;
            powerUpLocation.GetComponent<SpriteRenderer>().sprite = null;
        }
		slider.value=doom;
        if(powerUp)
        {
            if(powerUpName == "Nuke")
                powerUpLocation.GetComponent<SpriteRenderer>().sprite=powerUps[0]; 
            else if(powerUpName == "Auto")
                powerUpLocation.GetComponent<SpriteRenderer>().sprite = powerUps[1];
            else if (powerUpName == "Bomb")
                powerUpLocation.GetComponent<SpriteRenderer>().sprite = powerUps[2];
        }
	}
	IEnumerator Spawn()
	{
		yield return new WaitForSeconds(startTime);
		while (!gameover) 
		{
			for (int i=0; i<waveEnemyNumber; i++) 
			{
				Vector2 spawn = new Vector2 (Random.Range (-spawnPositions.x, spawnPositions.x), spawnPositions.y);
				GameObject enem = Instantiate (enemies, spawn, Quaternion.identity) as GameObject;
                enem.GetComponent<DestroyEnemy>().explosion = EnemyExplosm;
                enem.GetComponent<DestroyEnemy>().gM = gameObject;
				yield return new WaitForSeconds (waitTime);
			}
			yield return new WaitForSeconds(waveTime);
		}
	}
	public void setPowerUp(string name)
	{
		powerUpName = name;
		powerUp = true;
	}

    public void GameOver()
    {
        gameover = true;
        soulEmitter.active = false;
        crosshair.active = false;
        gameOverCanvas.active = true;

    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnReplay()
    {
        Application.LoadLevel("Main");
    }
}
