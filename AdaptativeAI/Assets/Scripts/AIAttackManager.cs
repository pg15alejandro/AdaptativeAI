//Copyright (c) 2019, Alejandro Silva

using UnityEngine;

public class AIAttackManager : MonoBehaviour
{
    [Header("NEEDED")]
    [SerializeField] private EnemyRegister _EnemyList;
    [SerializeField] private SOTransform _Player;
    [Header("TIME TO SWITCH ENEMIES")]
    [SerializeField] private float _MaxTimeBetweenChange;
    [Header("DEBUG")]
    [SerializeField] private float _TimeBetweenChange;


    private Animator _EnemyAnimator;
    private int _EnemyIndex = -1;

    private void Update()
    {

        if (_TimeBetweenChange > 0)
        {
            _TimeBetweenChange -= Time.deltaTime;  //decreasing the timer
        }

        if (_EnemyList.EnemiesInside.Count <= 0) return; //if there are enemies around the player
        if (_TimeBetweenChange <= 0)
        {
            _EnemyList.RegisterEnemiesOutside(_EnemyList.EnemiesInside[0].gameObject);    //moves the enemy back
            _TimeBetweenChange = _MaxTimeBetweenChange;   //reset the timer
            _EnemyIndex = Random.Range(0, _EnemyList.EnemiesOutside.Count); //gets another enemy
            if (_EnemyList.EnemiesOutside.Count > 0)
            {
                _EnemyList.RegisterEnemiesInside(_EnemyList.EnemiesOutside[_EnemyIndex].gameObject); //moves the enemy in
            }
        }
    }
}

