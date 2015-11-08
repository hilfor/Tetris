using UnityEngine;
using System.Collections;

public class Pad : MonoBehaviour {

    Transform localTransform;

    Vector3 prevMousePosition = Vector3.zero;
    Vector3 windowLowBorder;
    float forceDampner = 0.025f;


    void Start()
    {
        localTransform = transform;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDeltaPosition = Vector3.zero;
            if (!prevMousePosition.Equals(Vector3.zero))
            {
                mouseDeltaPosition = Input.mousePosition - prevMousePosition;
                mouseDeltaPosition.y = 0;
            }

            prevMousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit2d)
            {
                if (hit2d.collider.name == name)
                {
                    Debug.Log("Mouse moving by " + mouseDeltaPosition*forceDampner);
                    localTransform.Translate(mouseDeltaPosition*forceDampner);
                }
            }
        }
        else
        {
            prevMousePosition = Vector3.zero;
        }
        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(firstTouch.position);

            RaycastHit2D hit2d = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit2d)
            {
                Debug.Log("Hit something!");
                if (hit2d.collider.name == name)
                {
                    Debug.Log("Hit " + hit2d.collider.name);
                    Debug.Log("Moving the bar " + firstTouch.deltaPosition);
                    localTransform.Translate(new Vector3(firstTouch.deltaPosition.x * forceDampner, firstTouch.deltaPosition.y * forceDampner,0));
                }
            }
        }
    }

}
