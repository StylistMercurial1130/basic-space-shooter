using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectcontroller : MonoBehaviour
{
    public Vector2 projectileDirection;
    public float projectileSpeed = 5f;
    
    void Update()
    {
        ProjectileMotion();
    }

    private void ProjectileMotion()
    {
        transform.Translate(projectileDirection * Time.deltaTime * projectileSpeed, Space.World);

        if (transform.position.y > Camera.main.orthographicSize)
            Destroy(gameObject);
    }
}
