using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelGenerator : MonoBehaviour
{
    public class BG1
    {
        public Transform bg;
        private float size;
        private int numPlatforms;
        private int numEnemies;

        public BG1()
        {
            numPlatforms = 5;
            numEnemies = 3;
            size = bg.GetComponent<BoxCollider2D>().size.y;
        }

    }

    public BG1 GenerateBG1 = new();

}
