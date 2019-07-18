using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Transform target;//the target object
    private readonly float speedMod = 5.0f;//a speed modifier
    private Vector3 point;//the coord to the point where the camera looks at

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            var touchDeltaPosition =  Input.GetTouch(0).deltaPosition;
            transform.RotateAround(target.position, Vector3.down, -touchDeltaPosition.x * speedMod * Time.deltaTime);
            transform.RotateAround(target.position, Vector3.right, -touchDeltaPosition.y * speedMod * Time.deltaTime * 0.5f);
        }
    }

}
