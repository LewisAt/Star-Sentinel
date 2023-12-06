using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject prowlerPrefab;
    public GameObject flyingPrefab;

    [System.Serializable]
    public class BG
    {
        public GameObject background;
        public Transform backgroundSize;
        public Transform[] platformSpawnpoints;
        public Transform[] enemySpawnpoints;
        [SerializeField] public float size;
        public int numPlatforms;
        public int numEnemies;
    }

    public BG[] backgroundChoices;

    private void Start()
    {
        for (int i = 0; i < backgroundChoices.Length; i++)
        {
            backgroundChoices[i].size = 20f;
        }
    }

    void SpawnPage(int element)
    {
        if (element == 0)
        {
            Instantiate(backgroundChoices[element].background);
            for (int i = 0; i < backgroundChoices[element].platformSpawnpoints.Length; i++)
            {
                //Instantiate = (platformPrefab, backgroundChoices[element].platformSpawnpoints[i].transform.position, Quaternion.identity);



                for (int c = 0; c < backgroundChoices[element].platformSpawnpoints.Length; c++)
                {

                }
            }
        }

    }

}
