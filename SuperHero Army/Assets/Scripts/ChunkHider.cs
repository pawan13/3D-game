﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkHider : MonoBehaviour
{
    private Terrain[] chunks;
    public float visibleDistance;
    public int chunkSize;
    public float checkRate;
    // Start is called before the first frame update
    void Start()
    {
        // get all of the chunks 
        chunks = FindObjectsOfType<Terrain>();

        //Check the chunks every 'checkRate' seconds
        InvokeRepeating("CheckChunks", 0.0f, checkRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CheckChunks()
    {
        Vector3 playerPos = transform.position;
        playerPos.y = 0;

        //loop through each chunk 
        foreach(Terrain chunk in chunks)
        {
            //get the center pos of the chunk 
            Vector3 chunkCenterPos = chunk.transform.position + new Vector3(chunkSize / 2, 0, chunkSize / 2);

            //Check the distance 
            if (Vector3.Distance(playerPos, chunkCenterPos) > visibleDistance)
                chunk.gameObject.SetActive(false);
            else
                chunk.gameObject.SetActive(true);
        }
    }
}
