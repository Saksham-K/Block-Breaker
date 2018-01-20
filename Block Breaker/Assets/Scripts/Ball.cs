using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Slider slider;
	private Vector3 sliderToBallVector;
	private bool hasStarted=false;

	// Use this for initialization
	void Start () {
		slider=GameObject.FindObjectOfType<Slider>();
		sliderToBallVector=this.transform.position- slider.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted) {
			this.transform.position=slider.transform.position+sliderToBallVector;
			if(Input.GetMouseButtonDown(0)){
				//this.rigidbody2D.velocity= new Vector2(2f,10f);   //deprecated
				this.GetComponent<Rigidbody2D>().velocity=new Vector2(2f,7f);
				//this.GetComponent<Rigidbody2D>().velocity=new Vector2(0f,0f);
				hasStarted=true;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		this.GetComponent<Rigidbody2D>().velocity+= new Vector2(Random.Range(-0.2f,0.2f),Random.Range(-0.2f,0.2f));
	}
}
