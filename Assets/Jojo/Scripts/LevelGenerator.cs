using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class LevelGenerator : MonoBehaviour
{
    public LevelGenerator instance;
    public GameObject platformPrefab;
    public GameObject prowlerPrefab;
    public GameObject flyingPrefab;
    public float pageSize;
    public int GlobalCurrentRoll;
    public float pageOffset;
    public int previousPage;

    public BGManager[] backgroundChoices;
    private Transform[] tempPlatforms;
    private Transform[] tempProwlers;
    private Transform[] tempFlyingThings;

    [System.Serializable]
    public class BGManager
    {
        public GameObject background;
        public Transform backgroundSize;
        [HideInInspector] public float size;
    }

    //CURRENT ISSUE: Backgrounds keep spawning once the first if statement is hit on TempPlayerMovement.
    //CURRENT ISSUE: Only the backgrounds move upwards on the y, everything else stays at 0.

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance);
        pageOffset = 0f;
        pageSize = backgroundChoices[0].background.GetComponent<BoxCollider2D>().size.y;
        for (int i = 0; i < backgroundChoices.Length; i++)
        {
            backgroundChoices[i].size = pageSize;
        }
    }

    private void Start()
    {
        CreatePage();
    }

    public void SpawnBackground(int element)
    {
        Transform currentPageTransform = backgroundChoices[element].backgroundSize;
        GameObject currentPage = backgroundChoices[element].background;
        GameObject tempPlatformParent = backgroundChoices[element].background.transform.
            Find("Platforms").gameObject;
        GameObject tempProwlerParent = backgroundChoices[element].background.transform.
            Find("Prowler").gameObject;
        GameObject tempFlyingThingParent = backgroundChoices[element].background.transform.
            Find("Flying Thing").gameObject;


        Instantiate(currentPage, new Vector3(currentPageTransform.position.x, currentPageTransform.position.y + pageOffset,
            currentPageTransform.position.z), Quaternion.identity);

        previousPage = element;

        SpawnPlatforms(tempPlatformParent);
        SpawnProwlers(tempProwlerParent);
        SpawnFlyingThings(tempFlyingThingParent);
        pageOffset += 20f;
        AdjustPageSpawnPoint(pageOffset, tempPlatformParent, tempProwlerParent, tempFlyingThingParent);
    }

    public void AdjustPageSpawnPoint(float offset, GameObject a, GameObject b, GameObject c)
    {
        Vector3 offsetVector = new(0,offset,0);
        a.transform.position = offsetVector;
        b.transform.position = offsetVector;
        c.transform.position = offsetVector;
    }

    private void SpawnPlatforms(GameObject parent)
    {
        tempPlatforms = parent.GetComponentsInChildren<Transform>();
        for (int i = 1; i < tempPlatforms.Length; i++)
        {
            Instantiate(platformPrefab, tempPlatforms[i].position,
                platformPrefab.transform.rotation);
        }
    }

    private void SpawnProwlers(GameObject parent)
    {
        tempProwlers = parent.GetComponentsInChildren<Transform>();
        for (int i = 1; i < tempProwlers.Length; i++)
        {
            Instantiate(prowlerPrefab, tempProwlers[i].position,
                prowlerPrefab.transform.rotation);
        }
    }

    private void SpawnFlyingThings(GameObject parent)
    {
        tempFlyingThings = parent.GetComponentsInChildren<Transform>();
        for (int i = 1; i < tempFlyingThings.Length; i++)
        {
            Instantiate(flyingPrefab, tempFlyingThings[i].position,
                flyingPrefab.transform.rotation);
        }
    }

    public void CreatePage()
    {
        int currentRoll = GeneratePageNumber();
        GlobalCurrentRoll = currentRoll;
        SpawnBackground(currentRoll);
    }

    public void DestroyPage()
    {
       
    }

    public int GeneratePageNumber()
    {
        return Random.Range(0, backgroundChoices.Length);
    }
}
