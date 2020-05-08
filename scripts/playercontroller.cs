using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    private GameSceneController sceneController;
    public Rigidbody2D rb2d;
    public float movespeed;
    public float halfHeight;
    public float halfWidth;
    public SpriteRenderer Renderer;
    public Transform projectileOrigin;
    public projectcontroller projectilePrefab;

    void Start()
    {
        sceneController = FindObjectOfType<GameSceneController>();
        Renderer = GetComponent<SpriteRenderer>();
        movespeed = sceneController.playerSpeed;
        rb2d = GetComponent<Rigidbody2D>();

        halfHeight = Renderer.bounds.extents.y;
        halfWidth = Renderer.bounds.extents.x;


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            shootProjectile();
    }

    void FixedUpdate()
    {
        movePlayer(); 
    }

    void movePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalMovement = horizontalInput * Time.deltaTime * movespeed + transform.position.x;

        float right = sceneController.screenBounds.x - halfWidth;
        float left = -right;

        float limits = Mathf.Clamp(horizontalMovement,left,right);

        transform.position = new Vector2(limits, transform.position.y);
    }

    private void shootProjectile()
    {
        Vector2 Origin = projectileOrigin.position;
        projectcontroller projectile = Instantiate(projectilePrefab, Origin, Quaternion.identity);

        projectile.projectileSpeed = 2f;
        projectile.projectileDirection = Vector2.up;
    }
}
