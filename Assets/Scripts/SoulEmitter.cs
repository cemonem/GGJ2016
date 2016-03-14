using UnityEngine;
using System.Collections;

public class SoulEmitter : MonoBehaviour {

    public GameObject heavenSoul;
    public GameObject hellSoul;
    public GameObject otherSoul;
    public GameObject[] upgrades;

    public float emitterPeriod;
    public float soulFrequency;
    public float upgradeFrequency;
    public float soulSpeed;
    public float alpha;
    public float minPeriod;


    private float currentTime;
    private float totalFrequency;
    private Vector3 spawnPosition;
	// Use this for initialization
	void Start () {
        totalFrequency = soulFrequency + upgradeFrequency;
        spawnPosition = GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if(currentTime > emitterPeriod)
        {
            currentTime -= emitterPeriod;
            emitterPeriod -= alpha;
            if(emitterPeriod < minPeriod)
            {
                emitterPeriod = minPeriod;
            }
            emitSouls();
        }
	}

    void emitSouls()
    {
        GameObject newSoul;
        float random = Random.value;
        if (random < soulFrequency / (3 * totalFrequency))
        {
            newSoul = hellSoul;
            newSoul = Instantiate(newSoul, spawnPosition, Quaternion.identity) as GameObject;
            newSoul.tag = "HSoul";
        }
        else if (random < 2 * soulFrequency / (3 * totalFrequency))
        {
            newSoul = heavenSoul;
            newSoul = Instantiate(newSoul, spawnPosition, Quaternion.identity) as GameObject;
            newSoul.tag = "CSoul";
        }
        else if (random < soulFrequency / totalFrequency)
        {
            newSoul = otherSoul;
            newSoul = Instantiate(newSoul, spawnPosition, Quaternion.identity) as GameObject;
            newSoul.tag = "OSoul";
        }
        else
        {
            newSoul = upgrades[(int)Random.Range(0,upgrades.Length)];
            newSoul = Instantiate(newSoul, spawnPosition, Quaternion.identity) as GameObject;
        }
        newSoul.GetComponent<Rigidbody2D>().velocity = new Vector2(-soulSpeed, 0);
    }
}
