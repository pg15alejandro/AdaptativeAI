//Copyright (c) 2019, Alejandro Silva and Diego Montoya in Collaboration with VFS

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
