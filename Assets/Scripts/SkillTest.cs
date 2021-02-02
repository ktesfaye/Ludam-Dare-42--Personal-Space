using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum directions
{
    stay, left, right, up, down
}
[CreateAssetMenu()]
public class SkillTest : ScriptableObject
{
    public List<directions> moveDir;
    //public int distance;
    public Sprite card;
}