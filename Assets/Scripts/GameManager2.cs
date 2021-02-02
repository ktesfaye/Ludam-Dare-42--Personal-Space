using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; //for scene change
using System.Collections.Generic;       //Allows us to use Lists. 

namespace Completed
{
    using System.Collections.Generic;       //Allows us to use Lists. 
    using UnityEngine.UI;                   //Allows us to use UI.

    public class GameManager2 : MonoBehaviour
    {

        public static GameManager2 instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
        public BoardManager2 boardScript;                        //Store a reference to our BoardManager which will set up the level [I may need to rename this based on how we choose to set up the board].
        private int level = 1;                                  //Current level number, expressed in game as "Year 1".
        private int stress = 0;                                 //the player's beginning stress level
        private int maxStress = 150;
        private int reputation = 50;                            //the player's beginning reputation level
        public int turncount = 0;                               //the current turn
        public int points = 100;                                //points
        public Slider stress_visual;
        public Text time_count;
        private int hours = 9;
        private int minutes = 00; 

        public CardManager cardManaging;
        public Spawn spawner;
        public PartyGoer playerx;
        public MoveSprite moveSprite;
        public Skill movement;
        public GameObject player;
        public List<GameObject> enemies;
        //PartyGoer toadd;
        //MoveSprite toaddx;
        //List<PartyGoer> enemix;
        //List<MoveSprite> enemovement;
        private int length = 30;
        List<PartyGoer> enemix = new List<PartyGoer>();
        List<MoveSprite> enemovement = new List<MoveSprite>();
        List<Skill> chosen = new List<Skill>();

        private bool canMove = true;

        // drop the gameobject in
        public GameObject triggerObject1;
        public GameObject triggerObject2;
        public GameObject triggerObject3;

        // stores the trigger/collider component of those objects
        private Collider1 trigger1;
        private Collider2 trigger2;
        private Collider3 trigger3;

        //Awake is always called before any Start functions
        void Awake()
        {

            // grab each component
            trigger1 = triggerObject1.GetComponent<Collider1>();
            trigger2 = triggerObject2.GetComponent<Collider2>();
            trigger3 = triggerObject3.GetComponent<Collider3>();

            playerx = player.GetComponent<PartyGoer>();
            moveSprite = player.GetComponent<MoveSprite>();
            for (int num = 0; num < enemies.Count; num++)
            {
                enemix.Add(enemies[num].GetComponent<PartyGoer>());
                enemovement.Add(enemies[num].GetComponent<MoveSprite>());
            }

            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            //DontDestroyOnLoad(gameObject);

            //Get a component reference to the attached BoardManager script
            //boardScript = GetComponent<BoardManager2>();

            //Call the InitGame function to initialize the first level 
            InitGame();
            stress_visual.value = stress;
            time_count.text = "Time:" + hours + ": 0" + minutes + " pm";
        }

        //Initializes the game for each level.
        void InitGame()
        {
            //Call the SetupScene function of the BoardManager script, pass it current level number.
            //[probably will need to change or get rid of this]
            //boardScript.SetupScene(level);

        }

        IEnumerator wait(float time, Skill movemnt)
        {
            canMove = false;
            
            for (int i = 0; i < 5; i++)
            { 
                moveSprite.move(playerx, movemnt.moveDir[i]);
                
                for (int j = 0; j < enemies.Count; j++)
                {
                    //using the move sprite for the jth enemy, taking the partygoer portion and then finding the direction for the ith steps
                    enemovement[j].move(enemix[j], chosen[j].moveDir[i]);
                }
                yield return new WaitForSeconds(time);
            }

            checkforDamage(trigger1, trigger2, trigger3);

            canMove = true;

            spawn_enemies();

            turncount++;
            set_time_text();


        }

        //a method to spawn enemies
        private void spawn_enemies()
        {
            if (turncount > 4 && turncount <= 9)
            {
                GameObject new_enemy = spawner.spawn(turncount);
                enemies.Add(new_enemy);
                enemix.Add(new_enemy.GetComponent<PartyGoer>());
                enemovement.Add(new_enemy.GetComponent<MoveSprite>());
            }

            if (turncount > 9 && turncount <= 18)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject new_enemy = spawner.spawn(turncount);
                    enemies.Add(new_enemy);
                    enemix.Add(new_enemy.GetComponent<PartyGoer>());
                    enemovement.Add(new_enemy.GetComponent<MoveSprite>());
                }
            }

            if (turncount > 18 && turncount <= 27)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject new_enemy = spawner.spawn(turncount);
                    enemies.Add(new_enemy);
                    enemix.Add(new_enemy.GetComponent<PartyGoer>());
                    enemovement.Add(new_enemy.GetComponent<MoveSprite>());
                }
            }

            if (27 < turncount)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject new_enemy = spawner.spawn(turncount);
                    enemies.Add(new_enemy);
                    enemix.Add(new_enemy.GetComponent<PartyGoer>());
                    enemovement.Add(new_enemy.GetComponent<MoveSprite>());
                }
            }
        }

        private void checkforDamage(Collider1 trig1, Collider2 trig2, Collider3 trig3)
        {
            if(trig1.entered)   
            {
                int addedstress = trig1.count * 3;
                stress += addedstress;
                //Debug.Log("Entered Zone 1," + "Count: " + trig1.count + "Added stress: " + addedstress + "Total Stress: " + stress);
            }

            if (trig2.entered)
            {
                int addedstress = trig2.count * 2;
                stress += addedstress;
                //Debug.Log("Entered Zone 2," + "Count: " + trig2.count + "Added stress: " + addedstress + "Total Stress: " + stress);
            }

            if (trig3.entered)
            {
                int addedstress = trig3.count * 1;
                stress += addedstress;
                //Debug.Log("Entered Zone 3," + "Count: " + trig3.count + "Added stress: " + addedstress + "Total Stress: " + stress);
            }
            stress_visual.value = stress;
        }

        private void set_time_text()
        {
            if (turncount < 12) {
                hours = 9;
                minutes = turncount * 5;
                time_count.text = "Time:" + hours + ":" + minutes + " pm";
                if (turncount == 1)
                {
                    time_count.text = "Time:" + hours + ":0" + minutes + " pm";
                }
            }

            if (turncount >= 12 && turncount < 24)
            {
                hours = 10;
                minutes = turncount * 5 - 60;
                time_count.text = "Time:" + hours + ":" + minutes + " pm";
                if (turncount == 12 || turncount == 13)
                {
                    time_count.text = "Time:" + hours + ":0" + minutes + " pm";
                }

            }

            if (turncount >= 24 && turncount < 36)
            {
                hours = 11;
                minutes = turncount * 5 - 120;
                time_count.text = "Time:" + hours + ":" + minutes + " pm";
                if (turncount == 24 || turncount == 25)
                {
                    time_count.text = "Time:" + hours + ":0" + minutes + " pm";
                }
            }

            if (turncount >= 36)
            {
                time_count.text = "Time: 12:00 midnight";
            }

        }

        private void Update()
        {
            if (canMove == true)
            {
                for (int num = 0; num < enemies.Count; num++)
                {
                    //chooses a random skill from each enemy's list of skills, then adds to chosen skills
                    chosen.Insert(num, enemix[num].visible[Random.Range(0, enemix[num].visible.Count)]);
                }

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    movement = playerx.visible[0];
                    StartCoroutine(wait(0.15f, movement));
                    //cardManaging.returnCard(0);
                    cardManaging.changeCardOne();
                }

                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    movement = playerx.visible[1];
                    StartCoroutine(wait(0.15f, movement));
                    //cardManaging.returnCard(1);
                    cardManaging.changeCardTwo();
                }

                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    movement = playerx.visible[2];
                    StartCoroutine(wait(0.15f, movement));
                    //cardManaging.returnCard(2);
                    cardManaging.changeCardThree();
                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    movement = playerx.visible[3];
                    StartCoroutine(wait(0.15f, movement));
                    //cardManaging.returnCard(3);
                    cardManaging.changeCardFour();
                }
            }
            if (turncount == 36) {
                SceneManager.LoadScene("Win Scene");
                turncount = 0;
                stress = 0;
            }

            if (stress >= 100) { 
                SceneManager.LoadScene("Lose Scene");
                stress = 0;
                turncount = 0;
            }
        }
    }
}   

