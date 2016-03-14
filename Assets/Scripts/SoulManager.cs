using UnityEngine;
using System.Collections.Generic;

public class SoulManager : MonoBehaviour {

    public GameObject[] boxes;

    public float scramblePeriod;
    private float currentTime = 0;

    private List<KeyCode> keyCodeList;

    // Use this for initialization
    void Start () {
        keyCodeList = new List<KeyCode>();
        keyCodeList.Add(KeyCode.Q);
        keyCodeList.Add(KeyCode.W);
        keyCodeList.Add(KeyCode.E);
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if(currentTime > scramblePeriod)
        {
            currentTime -= scramblePeriod;
            scrambleKeys();
        }

	}

    void scrambleKeys()
    {
        float leftKeys = 2.9f;
        List < KeyCode > keys = new List<KeyCode>(keyCodeList);
        for (int i = 0; i < 3; i++)
        {
            int pickedKey = (int)Random.Range(0, leftKeys);
            BoxKey boxKey = boxes[i].GetComponent<BoxKey>();
            boxKey.OnKeyChanged(keys[pickedKey]);
            keys.RemoveAt(pickedKey);
            leftKeys -= 1;
        }
    }
}
