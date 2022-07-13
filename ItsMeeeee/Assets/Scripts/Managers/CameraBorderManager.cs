using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorderManager 
{
    private Camera cam;
    public Vector2 screenBounds { get; private set; }

    public CameraBorderManager()
    {
        cam = Camera.main;
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="side"></param>
    /// <param name="outerMargin">Adds a distance to the border outside of the screen</param>
    /// <returns></returns>
    public Vector2 GetRandomPointOnScreenBorder(ScreenBorderSide side, float outerMargin = 0f)
    {
        switch (side)
        {
            case ScreenBorderSide.Bottom:
                return new Vector2(Random.Range(-screenBounds.x, screenBounds.x), -screenBounds.y - outerMargin);

            case ScreenBorderSide.Top:
                return new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + outerMargin);

            case ScreenBorderSide.Right:
                return new Vector2(screenBounds.x + outerMargin, Random.Range(screenBounds.y, -screenBounds.y));

            case ScreenBorderSide.Left:
                return new Vector2(-screenBounds.x - outerMargin, Random.Range(screenBounds.y, -screenBounds.y));

            default:
                return Vector2.zero;
        }
    }

    public Vector2 GetRandomPointOnScreenBorderClampedFromCenter(ScreenBorderSide side, float maxDistanceToCenter, float outerMargin = 0f)
    {
        float randomX = Random.Range(-screenBounds.x, screenBounds.x);
        randomX = Mathf.Clamp(randomX, -maxDistanceToCenter, maxDistanceToCenter);
        float randomY = Random.Range(-screenBounds.y, screenBounds.y);
        randomY = Mathf.Clamp(randomY, -maxDistanceToCenter, maxDistanceToCenter);

        switch (side)
        {
            case ScreenBorderSide.Bottom:
                return new Vector2(randomX, -screenBounds.y - outerMargin);

            case ScreenBorderSide.Top:
                return new Vector2(randomX, screenBounds.y + outerMargin);

            case ScreenBorderSide.Right:
                return new Vector2(screenBounds.x + outerMargin, randomY);

            case ScreenBorderSide.Left:
                return new Vector2(-screenBounds.x - outerMargin, randomY);

            default:
                return Vector2.zero;
        }
    }

    public Vector2 GetRandomPointOnScreenBorderClampedFromEdges(ScreenBorderSide side, float maxDistanceToEdges, float outerMargin = 0f)
    {
        float randomX = Random.Range(-screenBounds.x + maxDistanceToEdges, screenBounds.x - maxDistanceToEdges);
        float randomY = Random.Range(-screenBounds.y + maxDistanceToEdges, screenBounds.y - maxDistanceToEdges);

        switch (side)
        {
            case ScreenBorderSide.Bottom:
                return new Vector2(randomX, -screenBounds.y - outerMargin);

            case ScreenBorderSide.Top:
                return new Vector2(randomX, screenBounds.y + outerMargin);

            case ScreenBorderSide.Right:
                return new Vector2(screenBounds.x + outerMargin, randomY);

            case ScreenBorderSide.Left:
                return new Vector2(-screenBounds.x - outerMargin, randomY);

            default:
                return Vector2.zero;
        }
    }

    public bool IsWithinScreenBounds(Vector2 position, float margin = 2f)
    {
        return position.x < screenBounds.x + margin && position.x > -screenBounds.x - margin && position.y < screenBounds.y + margin && position.y > -screenBounds.y - margin;
    }

    public Vector2 GetRandomPointInScreenBounds(float margin = 0)
    {
        float X = UnityEngine.Random.Range(-screenBounds.x + margin, screenBounds.x - margin);
        float Y = UnityEngine.Random.Range(-screenBounds.y + margin, screenBounds.y - margin);

        return new Vector2(X, Y);
    }
}

public enum ScreenBorderSide { Bottom, Top, Right, Left}