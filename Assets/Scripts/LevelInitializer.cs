using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField] int height;
    [SerializeField] int width;
    [SerializeField] GameObject bricks;
    // Start is called before the first frame update
    void Start()
    {
        float spaceY = 0.25f;
        float spaceX = 0f;
        for(int i = 0; i<height; i++)
        {

            for (int j = 0; j < width; j++)
            {
                GameObject obj = Instantiate(bricks);
                obj.transform.SetParent(gameObject.transform);
                obj.transform.position = new Vector3((j * bricks.transform.localScale.x) + bricks.transform.localScale.x +1 + spaceX, 18 - i- spaceY, 0);
                spaceX += 0.25f;
            }
            spaceY += 0.25f;
            spaceX =0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
