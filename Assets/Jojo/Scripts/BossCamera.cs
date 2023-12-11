using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
    public GameObject player;
    private Camera mainCam;
    public CanvasGroup canvas;
    public bool startedPlaying;
    // Start is called before the first frame update

    private void Awake()
    {
        //startedPlaying = false;
        mainCam = GetComponent<Camera>();
    }
    void Start()
    {
        canvas.alpha = 0;
        mainCam.transform.position = player.transform.position + new Vector3(0,1,-10);
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
        
        yield return new WaitForSeconds(3f);
        while (elapsed <= time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);

            mainCam.orthographicSize = Mathf.Lerp(oldSize, newSize, t);
            mainCamVector.y = Mathf.Lerp(mainCam.transform.position.y, 9f, t);
            mainCam.transform.position = mainCamVector;
            yield return null;
        }
        for (int i = 0; i < 30; i++)
        {
            mainCamVector.y = Mathf.Lerp(mainCam.transform.position.y, 0f, 0.2f);
            mainCam.transform.position = mainCamVector;
            yield return new WaitForSeconds(0.05f);
        }
        for (int j = 0; j < 40; j++)
        {
            canvas.alpha = Mathf.Lerp(canvas.alpha, 1f, 0.2f);
            yield return new WaitForSeconds(0.1f);
            startedPlaying = true;
        }
    }
}
