using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwiperCamera : MonoBehaviour
{
    private const float timeBeforeStart = 2.5f;
    public Transform lookAt;
    private Vector3 offset;
    private float distance = 5.0f;
    private float yOffset = 3.5f;
    private Vector3 desiredRotation;

    public RectTransform virtualJoystick;

    private Vector2 touchPosition;
    private float swipeResistance;

    private float smootSpeed = 5.0f;

    private float startTime;
    private bool isInsideVirtualJoystickSpace = false;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        offset = new Vector3(0, yOffset, -1 * distance);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime < timeBeforeStart)
            return;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            SlideCamera(true);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            SlideCamera(false);

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(virtualJoystick, Input.mousePosition))
            {
                isInsideVirtualJoystickSpace = true;
            }
            else
            {
                touchPosition = Input.mousePosition;
            }

        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            if (isInsideVirtualJoystickSpace)
            {
                isInsideVirtualJoystickSpace = false;
                return;
            }
            float swipeForce = touchPosition.x - Input.mousePosition.x;
            //Mathf.Abs adalah sebuah static function variabel yang memiliki nilai float, mathf.abs juga memiliki parameter float, dan berguna untuk mengembalikan nilai dari parameternya tersebut.
            //misal kita tulis Debug.Log(Mathf.Abs(-10)); maka yang akan diprint adalah kebalikannya yaitu 10;
            if (Mathf.Abs(swipeForce) > swipeResistance)
            {
                if (swipeForce < 0)
                    SlideCamera(true);
                else
                    SlideCamera(false);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Time.time - startTime < timeBeforeStart)
            return;
        desiredRotation = lookAt.position + offset;
        ////jika smoothSpeed * time.deltaTime = 0 maka akan mengembalikan nilai dari posisi objek ini, tetapi jika hasilnya 1 maka akan mengembalikan nilai desiredRotation;
        transform.position = Vector3.Lerp(transform.position, desiredRotation, smootSpeed * Time.deltaTime);
        transform.LookAt(lookAt.position + Vector3.up);
    }

    private void SlideCamera(bool left)
    {
        if (left)
            offset = Quaternion.Euler(0, 90, 0) * offset;
        else
            offset = Quaternion.Euler(0, -90, 0) * offset;
    }
}
