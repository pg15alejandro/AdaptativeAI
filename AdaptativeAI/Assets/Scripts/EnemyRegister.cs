//Copyright (c) 2019, Alejandro Silva and Diego Montoya in Collaboration with VFS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRegister : MonoBehaviour
{
    public List<GameObject> EnemiesOutside = new List<GameObject>();
    public List<GameObject> EnemiesInside = new List<GameObject>();
    
    [Header("MAXIUM AMMOUNTS")]
    public int MaxiumEnemiesInside;
    [Header("ANGLES")]
    public float OutsideMaxAngleEnemies;
    public float InsideMaxAngleEnemies;
    [Header("DEBUG")]
    public int AmmountOfEnemiesAlerted;
    public int AmmountOfEnemiesInside;

    private void Update()
    {
        AmmountOfEnemiesAlerted = EnemiesOutside.Count;
        AmmountOfEnemiesInside = EnemiesInside.Count;
    }

    public void RegisterEnemiesInside(GameObject go)
    {
        if (EnemiesInside.Contains(go)) return;
        TryToRemoveFromOutside(go);
        EnemiesInside.Add(go);
    }

    public void RegisterEnemiesOutside(GameObject go)
    {
        if (EnemiesOutside.Contains(go)) return;
        TryToRemoveFromInside(go);
        EnemiesOutside.Add(go);
    }

    private void TryToRemoveFromInside(GameObject go)
    {
        if (EnemiesInside.Contains(go) == false) return;
        EnemiesInside.Remove(go);
    }

    private void TryToRemoveFromOutside(GameObject go)
    {
        if (EnemiesOutside.Contains(go) == false) return;
        EnemiesOutside.Remove(go);
    }
}
