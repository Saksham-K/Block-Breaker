using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour {

	private Vector2 touchOrigin=-Vector2.one;
	
	// Use this for initialization
	void Start () {
        #if UNITY_ANDROID
        string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
	}
	
	// Update is called once per frame
	void Update () {
			float mousePosInBlocks = Input.mousePosition.x/Screen.width*16;
	Vector3 mousePos = new Vector3(Mathf.Clamp(mousePosInBlocks,6.7f,13.8f),this.transform.position.y,-1);
	this.transform.position=mousePos;
		//print("mouse"+mousePos);

		//Check if Input has registered more than zero touches
            if (Input.touchCount > 0)
            {
                //Store the first touch detected.
                Touch myTouch = Input.touches[0];
                
                //Check if the phase of that touch equals Began
                if (myTouch.phase == TouchPhase.Began)
                {
                    //If so, set touchOrigin to the position of that touch
                    touchOrigin = myTouch.position;
                    //print("touch"+touchOrigin);
                }

                /*
                //If the touch phase is not Began, and instead is equal to Ended and the x of touchOrigin is greater or equal to zero:
                else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
                {
                    //Set touchEnd to equal the position of this touch
                    Vector2 touchEnd = myTouch.position;
                    
                    //Calculate the difference between the beginning and end of the touch on the x axis.
                    float x = touchEnd.x - touchOrigin.x;
                    
                    //Calculate the difference between the beginning and end of the touch on the y axis.
                    float y = touchEnd.y - touchOrigin.y;
                    
                    //Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
                    touchOrigin.x = -1;
                    
                    //Check if the difference along the x axis is greater than the difference along the y axis.
                    if (Mathf.Abs(x) > Mathf.Abs(y))
                        //If x is greater than zero, set horizontal to 1, otherwise set it to -1
                        horizontal = x > 0 ? 1 : -1;
                    else
                        //If y is greater than zero, set horizontal to 1, otherwise set it to -1
                        vertical = y > 0 ? 1 : -1;
                } */
            }


		
	}
	/*
	void OnMouseDrag ()
	{
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, 3, -11);
        //Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
		print("mousePosition is"+mousePosition);
		this.transform.position = mousePosition;
		print("transformPosition is"+this.transform.position);

		if ( Input.touchCount > 0 )
     {
         for (int i = 0; i<Input.touchCount; i++)
         {
             currentTouch = Input.GetTouch(i);
             if (Input.GetTouch(i).phase == TouchPhase.Moved)
             {
                 ray = Camera.main.ScreenPointToRay (Input.GetTouch(i).position);
                 if ( Physics.Raycast(ray, out rayHitInfo))
                 {
                     Vector2 v2 = currentTouch.deltaPosition;
						Vector3 v3 = new Vector3(v2.x,3f,-11);
                     this.transform.position = v3;
                 }
             }
         }
     }

	}*/
}
