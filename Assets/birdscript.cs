using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdscript : MonoBehaviour {
    public Rigidbody2D birdyRigidBody;
    public float flapStrength;
    public Logic logic;
    public bool isBirdAlive = true;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isBirdAlive){
            birdyRigidBody.velocity = Vector2.up * flapStrength;

        }
        OffScreenDeath();
     }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOverScreen();
        isBirdAlive = false;
    }
    public void OffScreenDeath()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        if (viewportPosition.x < 0f || viewportPosition.x > 1f ||
            viewportPosition.y < 0f || viewportPosition.y > 1f)
        {
            // The character is off-screen, so trigger death behavior here.
            logic.gameOverScreen();
            isBirdAlive = false;
        }
    }
}
