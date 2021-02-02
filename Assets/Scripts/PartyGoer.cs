using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PartyGoer : MonoBehaviour {

    public bool isPlayer;
    public List<Skill> skillSet_up;
    public List<Skill> skillSet_down;
    public List<Skill> skillSet_left;
    public List<Skill> skillSet_right;
    public List<Skill> visible;
    public int damage;
    //public Sprite sprite;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 
	}
}
