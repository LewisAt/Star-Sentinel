using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossSpawnMinions : MonoBehaviour
{
    

    [Header("Oxygen Info")]
    public Transform[] oxygenSpawners;
    public GameObject oxygenPrefab;
    private float respawnTime = 15f;
    private bool oxygenCooldown;

    [Header("Prowler Info")]
    public Transform[] prowlersSpawners;
    public GameObject prowlerPrefab;

    [Header("Alien Info")]
    public Transform[] alienSpawners;
    public GameObject alienPrefab;

    private void Start()
    {
        oxygenCooldown = false;
    }

    private void Update()
    {
        if (!oxygenCooldown)
        {
            StartCoroutine(SpawnOxygen());
        }
    }

    private IEnumerator SpawnOxygen()
    {
        oxygenCooldown = true;
        yield return new WaitForSeconds(respawnTime);
        for (int i = 0; i < oxygenSpawners.Length; i++)
        {
            if (oxygenSpawners[i].childCount == 0)
            {
                Instantiate(oxygenPrefab, oxygenSpawners[i]);
            }
        }
        oxygenCooldown = false;
    }
}
