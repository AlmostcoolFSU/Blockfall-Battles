using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionControl : MonoBehaviour {
    public GameObject[] blocks,playingBlocks;
    public GameObject Chosen;
    public int rand1, rand2, rand3, turn=1;
    public Transform pos1, pos2, pos3, pos4, pos5, pos6;
    public bool start=false;
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        // SpawnBlocks();
       // Debug.Log("Something works");
        SpawnBlocks();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("did it work?1");
            playingBlocks = GameObject.FindGameObjectsWithTag("BlockHolder");
            for (int i = 0; i< playingBlocks.Length; i++)
            {
                Debug.Log("Itteration");
                Debug.Log(i);
                rb =playingBlocks[i].GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.useGravity = true;
                Debug.Log("did it work?2");
               //GameObject.FindGameObjectsWithTag("BlockHolder").
            }
        }
           
    }
    public void SpawnBlocks()
    {
        rand1 = Random.Range(0, blocks.Length);
        rand2 = Random.Range(0, blocks.Length);
        if (rand2 == rand1)
        {
            rand2 = Random.Range(0, blocks.Length);
        }
        rand3 = Random.Range(0, blocks.Length);
        if (rand3 == rand2 || rand3 == rand1)
        {
            rand3 = Random.Range(0, blocks.Length);
        }
        if (turn == 1)
        { 
        Instantiate(blocks[rand1], pos1);
            // Instantiate(blocks[rand2], pos2);
            // Instantiate(blocks[rand3], pos3);
        }
        if (turn == 2)
        {

       
         Instantiate(blocks[rand1], pos6);
            // Instantiate(blocks[rand2], pos5);
            // Instantiate(blocks[rand3], pos4);
        }



    }
}
