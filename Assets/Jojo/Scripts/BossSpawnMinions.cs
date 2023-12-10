using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossSpawnMinions : MonoBehaviour
{
    [Header("Prowler Info")]
    public Transform[] prowlersSpawners;
    public GameObject prowlerPrefab;

    [Header("Alien Info")]
    public Transform[] alienSpawners;
    public GameObject alienPrefab;
}
