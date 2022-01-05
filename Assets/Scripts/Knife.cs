using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

	public Rigidbody rb;
	public float force;
	private Vector2 StartSwipe;
	private Vector2 EndSwipe;
	public float torque;
	void Start () {
		
	}
	private bool resetGame =false;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			resetGame=true;
			rb.isKinematic = false;
			StartSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		}

		if (Input.GetMouseButtonUp (0)) {
			resetGame=false;
			EndSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			Swipe ();
		}	
	}
	void Swipe(){
		Vector2 swipe = EndSwipe - StartSwipe;
		Debug.Log (swipe * force * Time.time);
		rb.AddForce (swipe * force * Time.time, ForceMode.Impulse);
		rb.AddTorque (0f, 0f, torque * Time.time, ForceMode.Impulse);
	}

	void OnTriggerEnter(){
		if(!resetGame)
		{
			rb.isKinematic = true;
		}
	}
}