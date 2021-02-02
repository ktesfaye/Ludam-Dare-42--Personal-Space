using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum direction
{
    stay, left, right, up, down
}
[CreateAssetMenu()]
public class Skill : ScriptableObject
{
    public List<direction> moveDir;
    //public int distance;
    public Sprite card;
}


