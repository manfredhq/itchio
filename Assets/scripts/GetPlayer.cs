﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{
    public GameObject getPlayer()
    {
        return FindObjectOfType<Player>().gameObject;
    }
}
