//Copyright (c) 2019, Alejandro Silva

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SOTransform _Player;

    void Update()
    {
        _Player.value = transform;    
    }
}
