using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    Camera mainCamera;
    public Transform target;//the target object
    private readonly float speedMod = 5.0f;//a speed modifier
    private Vector3 point;//the coord to the point where the camera looks at

    float touchesPrevPositionDiff, touchesCurrPositionDiff, zoomMod;
    Vector2 firstTouchPrevPosition, secondTouchPrevPosition;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            var touchDeltaPosition =  Input.GetTouch(0).deltaPosition;
            transform.RotateAround(target.position, Vector3.down, -touchDeltaPosition.x * speedMod * Time.deltaTime);
            transform.RotateAround(target.position, Vector3.right, -touchDeltaPosition.y * speedMod * Time.deltaTime * 0.5f);
        }
        
        if (Input.touchCount == 2)
        {
            Touch firstTouch, secondTouch;
            firstTouch = Input.GetTouch(0);
            secondTouch = Input.GetTouch(1);

            firstTouchPrevPosition = firstTouch.position - firstTouch.deltaPosition;
            secondTouchPrevPosition = secondTouch.position - secondTouch.deltaPosition;

            touchesPrevPositionDiff = (firstTouchPrevPosition - secondTouchPrevPosition).magnitude;
            touchesCurrPositionDiff = (firstTouch.position - secondTouch.position).magnitude;

            zoomMod = touchesPrevPositionDiff - touchesCurrPositionDiff;

            //if(touchesPrevPositionDiff > touchesCurrPositionDiff)
            //{
            //    mainCamera.fieldOfView += zoomMod * Time.deltaTime;
            //}
            //if (touchesPrevPositionDiff < touchesCurrPositionDiff)
            //{
            //    mainCamera.fieldOfView -= zoomMod * Time.deltaTime;
            //}
            mainCamera.fieldOfView += zoomMod * 0.1f;

        }
        mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, 60f, 150f);

    }

}
