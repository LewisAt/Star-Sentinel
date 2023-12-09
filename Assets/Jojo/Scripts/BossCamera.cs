using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    public GameObject player;
    private Camera mainCam;
    // Start is called before the first frame update

    private void Awake()
    {
        mainCam = GetComponent<Camera>();
    }
    void Start()
    {
        mainCam.transform.position = player.transform.position + new Vector3(0,2,-1);
        mainCam.orthographicSize = 2;
        StartCoroutine(resizeRoutine(mainCam.orthographicSize, 25, 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator resizeRoutine(float oldSize, float newSize, float time)
    {
        float elapsed = 0;
        Vector3 mainCamVector = mainCam.transform.position;
        while (elapsed <= time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);

            mainCam.orthographicSize = Mathf.Lerp(oldSize, newSize, t);
            mainCamVector.y = Mathf.Lerp(mainCam.transform.position.y, 0f, t);
            mainCam.transform.position = mainCamVector;
            yield return null;
        }
    }
}
