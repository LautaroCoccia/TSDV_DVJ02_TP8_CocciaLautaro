using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField] int height;
    [SerializeField] int width;
    [SerializeField] GameObject bricks;
    [SerializeField] GameObject limitPrefab;
    [SerializeField] GameObject player;
    [SerializeField] GameObject backgroundPrefab;
    [SerializeField] Camera mainCamera;
    [SerializeField] float positionX;
    [SerializeField] float positionY = 18;
    // Start is called before the first frame update
    void Start()
    {
        int colorIndex = 0;
        float spaceY = 0.25f;
        float spaceX = 0f;
        for(int i = 0; i<height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GameObject obj = Instantiate(bricks);
                LevelManager.Get().StartObj();
                MeshRenderer mesh = obj.GetComponent<MeshRenderer>();
                if( colorIndex == 0)
                {
                    mesh.material.color = Color.white;
                }
                else if(colorIndex == 1)
                {
                    mesh.material.color = Color.red;
                }
                else if (colorIndex == 2)
                {
                    mesh.material.color = Color.blue;
                }

                obj.transform.SetParent(gameObject.transform);
                obj.transform.position = new Vector3((j * bricks.transform.localScale.x) + bricks.transform.localScale.x  + spaceX, positionY - i- spaceY, 0);
                positionX = obj.transform.position.x;
                spaceX += 0.25f;
            }
            spaceY += 0.25f;
            spaceX =0;
            
            colorIndex++;
            if(colorIndex >3)
            {
                colorIndex = 0;
            }
        }
        for (int j = 0; j < 3; j++)
        {
            GameObject limit = Instantiate(limitPrefab);
            if (j == 0)
            {
                limit.transform.position = new Vector3(0, positionY / 2 + spaceY, 0);
                limit.transform.localScale = new Vector3(1, positionY + spaceY, 1);
            }
            else if (j == 1)
            {
                limit.transform.position = new Vector3(positionX + bricks.transform.localScale.x + spaceX, positionY / 2 +spaceY, 0);
                limit.transform.localScale = new Vector3(1, positionY +spaceY, 1);
            }
            else if (j == 2)
            {
                positionX = (positionX + bricks.transform.localScale.x + spaceX) / 2;
                limit.transform.position = new Vector3(positionX , positionY + bricks.transform.localScale.y + spaceY, 0);
                limit.transform.localScale = new Vector3(positionX *2 , 1, 1);
            }
        }
        player.transform.position = new Vector3(positionX, player.transform.position.y, 0);
        GameObject background = Instantiate(backgroundPrefab);
        background.transform.position = new Vector3(positionX, positionY / 2, 0);
        background.transform.localScale = new Vector3(positionX / 4, 1, positionY / 4);
        mainCamera.transform.position = new Vector3(positionX, positionY  / 2 + spaceY, mainCamera.transform.position.z);
    }
}
