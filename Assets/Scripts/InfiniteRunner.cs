using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRunner : MonoBehaviour
{
    public PlayerController2D player;

    private GameObject chunkRoot;
    private GameObject[] chunks;
    private float position = 0f;

    private GameObject[] chunkPrefabs;

	void Start ()
    {
	    if(player == null)
        {
            Debug.LogError("Hook Up Yo Shit!");
        }

        chunkPrefabs = Resources.LoadAll<GameObject>("Chunks");

        chunkRoot = new GameObject("Chunks");

        chunks = new GameObject[2];

        chunks[0] = GenerateChunkZero();

        chunks[1] = GenerateRandomChunk();
    }

	void Update ()
    {
		if(player.transform.position.x > position + 1f)
        {
            Destroy(chunks[0]);
            chunks[0] = chunks[1];
            chunks[1] = GenerateRandomChunk();
        }
	}

    private GameObject GenerateChunkZero()
    {
        return Instantiate(chunkPrefabs[0]);
    }

    private GameObject GenerateRandomChunk()
    {
        var rand = Random.value * chunkPrefabs.Length;

        position += 20f;

        return Instantiate(chunkPrefabs[(int)rand], new Vector3(position, 0, 0), Quaternion.identity);
    }
}
