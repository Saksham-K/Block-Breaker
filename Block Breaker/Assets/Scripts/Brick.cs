using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public int maxHits;
	public Sprite[] hitSprites;

	private int timesHit;
	private LevelManager levelmgr;
	private bool isBreakable ;

	public static int breakableCount=0;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
			print(breakableCount);
		}
		timesHit=0;
		levelmgr= GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionExit2D (Collision2D collision)
	{
		if (isBreakable) {
			HanldeHits ();
		}
	}

	void HanldeHits ()
	{
		timesHit++;
		if (gameObject.ToString ().StartsWith ("1hit") && timesHit == 1) {
			breakableCount--;
			Destroy (gameObject);
			GoToWin();
		} else if (gameObject.ToString ().StartsWith ("2hit") && timesHit == maxHits) {
			breakableCount--;
			Destroy (gameObject);
			GoToWin();
		} else {
			LoadSprites ();
		}
		print(breakableCount);
	}

	void LoadSprites ()
	{
		int spriteIndex=timesHit-1;
		this.GetComponent<SpriteRenderer>().sprite=hitSprites[spriteIndex];
	}

	void GoToWin ()
	{
		levelmgr.BrickDestroy ();
	}

}
