using UnityEngine;
using System.Collections;

public class ClampRectTransform : MonoBehaviour {

	public float padding = 10.0f;
	public float elementSize = 128.0f;
	public float viewSize = 250.0f;
	public float paddingLeft = 5;

	private RectTransform rt;
	private int amountElement;
	private float contentSize;

	// Use this for initialization
	private void Start () 
	{
		rt = GetComponent<RectTransform>();
        rt.localPosition = new Vector3(100, rt.localPosition.y, rt.localPosition.z);
    }
	
	// Update is called once per frame
	private void Update () 
	{
		//Clamp our rect transform
		amountElement = rt.childCount; //the number of the children the Transform has 
		//disini kita memiliki beberapa children(tergantung dari level yang ada) dari transform levelBtnContainer, untuk mengechecknya silahkan klik play
		//contentSize = ((3 * (128.0f + 10)) - 250.0f) * 0.4570301) *catatan : rt.localScale.x nilainya diperoleh dari nilai RectTransform objek scale x
		contentSize = ((amountElement * (elementSize + padding)) - viewSize) * rt.localScale.x; //the scale of the transform relative to the parent
		/*localPosition = Position of the transform relative to the parent transform
		 * If  the transform has no parent it is same like Transform.position
		 * Jika localposition.x > 10 + 5
		 */
		if(rt.localPosition.x > padding + paddingLeft)
		{
			//merubah posisi dari rt
			rt.localPosition = new Vector3 (padding + paddingLeft, rt.localPosition.y, rt.localPosition.z);
		}
		else if(rt.localPosition.x < -contentSize)
		{
			rt.localPosition = new Vector3 (-contentSize, rt.localPosition.y, rt.localPosition.z);
		}
	}
}
