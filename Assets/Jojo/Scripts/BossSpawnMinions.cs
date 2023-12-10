using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossSpawnMinions : MonoBehaviour
{
    private BossHealth bossInfo;
    private float bossHealth;

    [Header("Oxygen Info")]
    public Transform[] oxygenSpawners;
    public GameObject oxygenPrefab;
    private float oxygenRespawnTime = 15f;
    private bool oxygenCooldown;

    [Header("Prowler Info")]
    public Transform[] prowlersSpawners;
    public GameObject prowlerPrefab;
    private bool prowlerCooldown;

    [Header("Alien Info")]
    public Transform[] alienSpawners;
    public GameObject alienPrefab;
    private bool alienCooldown;

    private float respawnTime;

    private void Start()
    {
        bossInfo = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossHealth>();
        oxygenCooldown = false;
        prowlerCooldown = false;
        alienCooldown = false;
    }

    private void Update()
    {
        respawnTime = Random.Range(5, 15);
        bossHealth = bossInfo.health;
        if (!oxygenCooldown)
        {
            StartCoroutine(SpawnOxygen());
        }
        if (bossHealth < 400 && !alienCooldown)
        {
            StartCoroutine(SpawnAlien());
        }
        if (bossHealth < 300 && !prowlerCooldown)
        {
            StartCoroutine(SpawnProwlers());
        }
    }

    private IEnumerator SpawnOxygen()
    {
        oxygenCooldown = true;
        yield return new WaitForSeconds(oxygenRespawnTime);
        for (int i = 0; i < oxygenSpawners.Length; i++)
        {
            if (oxygenSpawners[i].childCount == 0)
            {
                Instantiate(oxygenPrefab, oxygenSpawners[i]);
            }
        }
        oxygenCooldown = false;
    }

    private IEnumerator SpawnAlien()
    {
        alienCooldown = true;
        yield return new WaitForSeconds(respawnTime);
        for (int i = 0; i < alienSpawners.Length; i++)
        {
            if (alienSpawners[i].childCount == 0)
            {
                Instantiate(alienPrefab, alienSpawners[i]);
            }
        }
        alienCooldown = false;
    }
    private IEnumerator SpawnProwlers()
    {
        prowlerCooldown = true;
        yield return new WaitForSeconds(respawnTime);
        for (int i = 0; i < prowlersSpawners.Length; i++)
        {
            if (prowlersSpawners[i].childCount == 0)
            {
                Instantiate(prowlerPrefab, prowlersSpawners[i]);
            }
        }
        prowlerCooldown = false;
    }
}
