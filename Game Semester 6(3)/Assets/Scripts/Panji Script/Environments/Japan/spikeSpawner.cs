using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeSpawner : MonoBehaviour
{
    private Spikes Spike;
    public Transform spikeSpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        Spike = GameObject.Find("SpikesSpawn").GetComponent<Spikes>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player" || coll.gameObject.tag == "Player2")
        {
            Debug.Log("You Hit "+gameObject);
            StartCoroutine(spawnSpike(coll.gameObject));
        }
    }

    IEnumerator spawnSpike(GameObject spikes)
    {
        yield return new WaitForSeconds(0);

        for (int i=0; i < Spike.spawnPoints.Length; i++)
        {
            if(Spike.spawnPoints[i] == spikeSpawnPoints)
            {
                Spike.possibleSpike.Add(Spike.spawnPoints[i]);
            }
        }
        Destroy(gameObject);
    }
}
