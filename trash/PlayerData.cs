using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData : MonoBehaviour{


    public int level;
    public float healthMax;
    public float healthNow;
    public float[] position;

    public PlayerData(PlayerHealth Player)
    {
        healthNow = Player.PHealth;
        healthMax = Player.PMaxHealth;

        position = new float[3];
        position[0] = Player.transform.position.x;
        position[1] = Player.transform.position.y;
        position[2] = Player.transform.position.z;
    }

    public PlayerData(ExperienceLevels Experiences)
    {
        level = Experiences.level;
    }
}
