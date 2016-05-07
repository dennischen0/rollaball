using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Rigidbody rb;
	public float speed;
	private int count;
	public Text countText;
	public Text winText;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void OnTriggerEnter(Collider other) {
//		Destroy (other.gameObject);
		if (other.gameObject.CompareTag ("pickup")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 13) {
			winText.text = "You Win!!";
		}
	}

	void FixedUpdate () {
		int fingerCount = 0;
		Vector2 touchPosition;
//		foreach (Touch touch in Input.touches) {
//			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
//				fingerCount++;
//			if (touch.phase == TouchPhase.Began) {
//				touchPosition = touch.position;
//
//
//				int x, y;
//				if (touchPosition.x > Screen.width / 2f) {
//					x = 1;
//				} else {
//					x = -1;
//				}
//				if (touchPosition.y > Screen.height / 2f) {
//					y = 1;
//				} else {
//					y = -1;
//				}
//				Vector3 movement = new Vector3 (x, 0, y);
//
//				rb.AddForce (movement * speed);
//			}
//		}
//
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);

	}
}
