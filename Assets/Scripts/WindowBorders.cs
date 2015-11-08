using UnityEngine;
using System.Collections;

public class WindowBorders
{

    Vector3 topRight;
    Vector3 topLeft;
    Vector3 bottomRight;
    Vector3 bottomLeft;

    static WindowBorders instance = null;

    public static WindowBorders GetInstance()
    {
        if (instance == null)
        {
            instance = new WindowBorders();
        }
        return instance;
    }

    // Use this for initialization
    WindowBorders()
    {
        topRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        topLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
        bottomRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        bottomLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Debug.Log("window top right " + topRight);
        Debug.Log("window top left " + topLeft);
        Debug.Log("window bottom left" + bottomLeft);
        Debug.Log("window bottom right" + bottomRight);
    }

    public bool CheckTop(Vector3 point)
    {
        if (point.y < topRight.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckRight(Vector3 point)
    {
        if (point.x < topRight.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckLeft(Vector3 point)
    {
        if (point.x > topLeft.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckBottom(Vector3 point)
    {
        if (point.y > bottomLeft.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckOnScreen(Vector3 point)
    {
        if (CheckBottom(point) && CheckLeft(point) && CheckRight(point) && CheckTop(point))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
