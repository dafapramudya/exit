using UnityEngine;
using System.Collections;

public class CameraMotor : MonoBehaviour
{
    private const float timeBeforeStart = 2.5f;
    //public Transform lookAt;
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
	void Start ()
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
            //RectangleContainsScreenPoint adalah bool function yang memiliki MA public static.
            //Struktur = public static bool RectangleContainsScreenPoint(RectTransform rect, Vector2 screenPoint, Camera cam(Optional))
            //rect = TheRectTransform to test with, screenPoint = the screen point to test, cam = The camera from which the test performed.
            //akan mengembalikan nilai true jika Point berada di samping Rectangle

            //Jika kita mengklik mouse pada luar RectTransform virtualJoystick maka:
            if(RectTransformUtility.RectangleContainsScreenPoint(virtualJoystick, Input.mousePosition))
            {
                isInsideVirtualJoystickSpace = true;
            }
            //Tetapi jika kita mengklik mouse tepat di RectTransform virtualJoystick maka:
            else
            {
                touchPosition = Input.mousePosition;
            }
            
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            //Pas mouse masih ditekan isInsideVirtualJoystick bernilai true, setelah diangkat nilainya jadi false dan memberhentikan kondisi ini.
            if(isInsideVirtualJoystickSpace)
            {
                isInsideVirtualJoystickSpace = false;
                return;
            }


            /*>> Jika input didalam RectTransform virtualJoystick

            jika nilai posisi dari input.MousePosition = (20, 35, 10)
			touchPosition = (20, 35, 10)


            >> Jika input diluar

            pasti kita akan menginput lagi di luar posisi Rect maka nilai dari Input.mousePosition pun akan berubah. misal(40, 111, 123)

            >> Inti dari ini kita akan membahas swipeForce = touchPosition.x - input.mousePosition.x

            maka:

            20 - 40*/
            float swipeForce = touchPosition.x - Input.mousePosition.x;
            //Mathf.Abs adalah sebuah static function variabel yang memiliki nilai float, mathf.abs juga memiliki parameter float, dan berguna untuk mengembalikan nilai dari parameternya tersebut.
            //misal kita tulis Debug.Log(Mathf.Abs(-10)); maka yang akan diprint adalah kebalikannya yaitu 10;
            if(Mathf.Abs(swipeForce) > swipeResistance)
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
        desiredRotation = offset;
        //jika smoothSpeed * time.deltaTime = 0 maka akan mengembalikan nilai dari posisi objek ini, tetapi jika hasilnya 1 maka akan mengembalikan nilai desiredRotation;

        /*Vector3.Lerp
        Interpolates between two vector by the t. ex(a, b, t);
        if t = 0 lerp will return a value, if t = 1 lerp will return b value, and if t = 0.5 lerp will return the point midway between a and b.
        */

        //Jika smootSpeed * Time.deltaTime !0 maka kita akan menentukan posisi transform baru dari desiredRotation,
        transform.position = Vector3.Lerp(transform.position, desiredRotation, smootSpeed * Time.deltaTime);
        //transform.LookAt(transform.position + Vector3.up);
    }

    private void SlideCamera(bool left)
    {
        if (left)
            //Quaternion.Euler = Return rotation that x in x degrees, y in y degrees, and z in z degrees
            //struktur = public static Quaternion Euler(float a, float b, float c); atau
            //public static Quaternion Euler(Vector 3);
            offset = Quaternion.Euler(0, 90, 0) * offset;
        else
            offset = Quaternion.Euler(0, -90, 0) * offset;
    }
}
