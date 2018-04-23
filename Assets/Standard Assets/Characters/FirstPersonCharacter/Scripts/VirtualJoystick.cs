using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        private Image bgImg;
        private Image joystickImg;
        //walaupun inputDirection memiliki hak akses publik namun karena menggunakan properti set dan get maka, variabel inputDirection tidak akan muncul di inspektor.
        public Vector3 inputDirection { set; get; }

        // Use this for initialization
        void Start()
        {
            inputDirection = Vector3.zero;
            bgImg = GetComponent<Image>();
            joystickImg = transform.GetChild(0).GetComponent<Image>();
        }

        public virtual void OnDrag(PointerEventData ped)
        {
            Vector2 pos = Vector2.zero;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
            {
                pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
                pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

                float x = (bgImg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
                float y = (bgImg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

                inputDirection = new Vector3(x, 0, y);
                inputDirection = (inputDirection.magnitude > 1) ? inputDirection.normalized : inputDirection;

                Debug.Log(inputDirection);

                joystickImg.rectTransform.anchoredPosition =
                    new Vector3(inputDirection.x * (bgImg.rectTransform.sizeDelta.x / 3)
                    , inputDirection.z * (bgImg.rectTransform.sizeDelta.y / 3));
            }
        }

        public virtual void OnPointerDown(PointerEventData ped)
        {
            OnDrag(ped);
        }

        public virtual void OnPointerUp(PointerEventData ped)
        {
            inputDirection = Vector3.zero;
            joystickImg.rectTransform.anchoredPosition = Vector3.zero;
        }
    }
}