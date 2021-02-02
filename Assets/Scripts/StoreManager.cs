using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour {

	public ShopDeck Tier1;

	public List<Skill> cardShop = new List<Skill>();
	public List<GameObject> shopSprites = new List<GameObject>();

	void Awake () {

	}

	// Use this for initialization
	void Start () {

		//pick the cards to put into the store


		//first card
		Random rnd = new Random();
		int randNum = Random.Range(0, Tier1.possibleSkills.Count);
		cardShop.Add(Tier1.possibleSkills[randNum]);
		shopSprites.Add(Tier1.skillSprites[randNum]);
		shopSprites[0].transform.position = new Vector3(-237, -128, 0);
		Tier1.possibleSkills.RemoveAt(randNum);
		Tier1.skillSprites.RemoveAt(randNum);

		//second card
		randNum = Random.Range(0, Tier1.possibleSkills.Count);
		cardShop.Add(Tier1.possibleSkills[randNum]);
		shopSprites.Add(Tier1.skillSprites[randNum]);
		Tier1.possibleSkills.RemoveAt(randNum);
		Tier1.skillSprites.RemoveAt(randNum);
		shopSprites[1].transform.position = new Vector3(-170, -128, 0);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
