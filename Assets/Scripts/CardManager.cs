using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    public GameObject Player;
    PartyGoer playerx;
    int cardnum;
    Skill card;
    Skill skillone;
    Skill skilltwo;
    Skill skillthree;
    Skill skillfour;
    Skill cardReplace;
    //public List<GameObject> all_card_sprites;
    public List<GameObject> all_card_panels;
    public List<Skill> stillAvailable_up;
    public List<Skill> stillAvailable_down;
    public List<Skill> stillAvailable_left;
    public List<Skill> stillAvailable_right;
    GameObject cardone;
    GameObject cardtwo;
    GameObject cardthree;
    GameObject cardfour;

    public Dictionary<Skill, GameObject> deck = new Dictionary<Skill, GameObject>();
    
    void Awake ()
    {
        playerx = Player.GetComponent<PartyGoer>();

        int uskillsetsize = playerx.skillSet_up.Count;
        stillAvailable_up = playerx.skillSet_up;
        for (int i = 0; i < uskillsetsize; i++)
        {
            deck.Add(playerx.skillSet_up[i], all_card_panels[i]);
        }

        int dskillsetsize = playerx.skillSet_down.Count;
        stillAvailable_down = playerx.skillSet_down;
        for (int i = 0; i < dskillsetsize; i++)
        {
            deck.Add(playerx.skillSet_down[i], all_card_panels[i + 5]);
        }

        int lskillsetsize = playerx.skillSet_left.Count;
        stillAvailable_left = playerx.skillSet_left;
        for (int i = 0; i < lskillsetsize; i++)
        {
            deck.Add(playerx.skillSet_left[i], all_card_panels[i + 10]);
        }

        int rskillsetsize = playerx.skillSet_right.Count;
        stillAvailable_right = playerx.skillSet_right;
        for (int i = 0; i < rskillsetsize; i++)
        {
            deck.Add(playerx.skillSet_right[i], all_card_panels[i + 15]);
        }

    }
    // Use this for initialization
    void Start () {
        playerx = Player.GetComponent<PartyGoer>();

        skillone = chooseUpCard();
        playerx.visible.Insert(0, skillone);
        stillAvailable_up.Remove(skillone);

        skilltwo = chooseDownCard();
        playerx.visible.Insert(1, skilltwo);
        stillAvailable_down.Remove(skilltwo);

        skillthree = chooseLeftCard();
        playerx.visible.Insert(2, skillthree);
        stillAvailable_left.Remove(skillthree);

        skillfour = chooseRightCard();
        playerx.visible.Insert(3, skillfour);
        stillAvailable_right.Remove(skillfour);

        cardone = deck[playerx.visible[0]];
        cardone.transform.position = new Vector3(160, 120, 0);
        cardtwo = deck[playerx.visible[1]];
        cardtwo.transform.position = new Vector3(160, 40, 0);
        cardthree = deck[playerx.visible[2]];
        cardthree.transform.position = new Vector3(100, 40, 0);
        cardfour = deck[playerx.visible[3]];
        cardfour.transform.position = new Vector3(220, 40, 0);
        
	}
	
    public void changeCardOne()
    {
        card = chooseUpCard();
        returnCard_up(0);
        playerx.visible.Insert(0, card);
        stillAvailable_up.Remove(card);
        cardone.transform.position = new Vector3(1000, 1000, 0);
        cardone = deck[playerx.visible[0]];
        cardone.transform.position = new Vector3(160, 120, 0);
    }

    public void changeCardTwo()
    {
        card = chooseDownCard();
        returnCard_down(1);
        playerx.visible.Insert(1, card);
        stillAvailable_down.Remove(card);
        cardtwo.transform.position = new Vector3(1000, 1000, 0);
        cardtwo = deck[playerx.visible[1]];
        cardtwo.transform.position = new Vector3(160, 40, 0);
    }

    public void changeCardThree()
    {
        card = chooseLeftCard();
        returnCard_left(2);
        playerx.visible.Insert(2, card);
        stillAvailable_left.Remove(card);
        cardthree.transform.position = new Vector3(1000, 1000, 0);
        cardthree = deck[playerx.visible[2]];
        cardthree.transform.position = new Vector3(100, 40, 0);
    }

    public void changeCardFour()
    {
        card = chooseRightCard();
        returnCard_right(3);
        playerx.visible.Insert(3, card);
        stillAvailable_right.Remove(card);
        cardfour.transform.position = new Vector3(1000, 1000, 0);
        cardfour = deck[playerx.visible[3]];
        cardfour.transform.position = new Vector3(220, 40, 0);
    }

    Skill chooseUpCard()
    {
        cardnum = Random.Range(0, stillAvailable_up.Count);
        return stillAvailable_up[cardnum];

    }

    Skill chooseDownCard()
    {
        cardnum = Random.Range(0, stillAvailable_down.Count);
        return stillAvailable_down[cardnum];

    }

    Skill chooseLeftCard()
    {
        cardnum = Random.Range(0, stillAvailable_left.Count);
        return stillAvailable_left[cardnum];

    }

    Skill chooseRightCard()
    {
        cardnum = Random.Range(0, stillAvailable_right.Count);
        return stillAvailable_right[cardnum];

    }

    public void returnCard_up(int num)
    {
        //given an index, return the card in the visible location
        //to stillAvailable list
        stillAvailable_up.Add(playerx.visible[num]);
        playerx.visible.RemoveAt(num);

    }

    public void returnCard_down(int num)
    {
        //given an index, return the card in the visible location
        //to stillAvailable list
        stillAvailable_down.Add(playerx.visible[num]);
        playerx.visible.RemoveAt(num);

    }

    public void returnCard_left(int num)
    {
        //given an index, return the card in the visible location
        //to stillAvailable list
        stillAvailable_left.Add(playerx.visible[num]);
        playerx.visible.RemoveAt(num);

    }

    public void returnCard_right(int num)
    {
        //given an index, return the card in the visible location
        //to stillAvailable list
        stillAvailable_right.Add(playerx.visible[num]);
        playerx.visible.RemoveAt(num);

    }
}
