using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    public float playerSpeed;
    public float spawnBoundsOffset = 2.5f;
    public Vector3 screenBounds;
   

    public Enemycontroller enemyPrefab;

    void Start() 
    {
        playerSpeed = 10f;
        
        screenBounds = Getscreebounds();
        StartCoroutine(spawnEnemies());
    }

    private Vector3 Getscreebounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);

        return mainCamera.ScreenToWorldPoint(screenVector);
    }

    private IEnumerator spawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(2);

        while(true)
        {
            float Horizontal = Random.Range(-screenBounds.x + spawnBoundsOffset, screenBounds.x - spawnBoundsOffset);
            Vector2 enemyspawnVector = new Vector2(Horizontal, screenBounds.y);

            Instantiate(enemyPrefab, enemyspawnVector, Quaternion.identity);
            yield return wait;
        }    
    }


}
