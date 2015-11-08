using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public Vector3 velosity;
    SpriteRenderer spriteRenderer;


    void Start()
    {
        velosity = Random.onUnitSphere;
        velosity.z = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();

        
        //Debug.Log("Sphere bottom right" + bottomRight);
        //Debug.Log("Sphere top left" + topLeft);
    }

    void Update()
    {
        Vector3 bottomRight = transform.position + spriteRenderer.bounds.max;
        Vector3 topLeft = transform.position + spriteRenderer.bounds.min;
        if (!WindowBorders.GetInstance().CheckRight(bottomRight) || !WindowBorders.GetInstance().CheckLeft(topLeft))
        {
            ChangeHorizonatalMovement();
        }

        if (!WindowBorders.GetInstance().CheckBottom(bottomRight) || !WindowBorders.GetInstance().CheckTop(topLeft))
        {
            ChangeVerticalMovement();
            
        }
        transform.Translate(velosity * Time.deltaTime);

    }

    void FixedUpdate()
    {

    }

    void ChangeVerticalMovement()
    {
        Debug.Log("Changing Vertical velocity");
        velosity.y *= -1;
    }

    void ChangeHorizonatalMovement()
    {
        Debug.Log("Changing Horizontal velocity");
        velosity.x *= -1;

    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            ChangeHorizonatalMovement();
            ChangeVerticalMovement();
        }

    }
}
