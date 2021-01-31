using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{    
    [SerializeField]
    private float _speed = 1f;

    private int nextTarget = 0;

    private bool foward = true;

    public Transform target = null;

    private void Awake()
    {
        target = transform.parent.GetChild(2);
        nextTarget = 3;
    }

    private void Update()
    {
        float step = _speed * Time.deltaTime; // step size = speed * frame time
        transform.position = Vector3.MoveTowards(transform.position, target.position, step); // moves position a step closer to the target position
        if(transform.position.x == target.position.x){
            getNextTargetIndex();
        }
    }

    private void getNextTargetIndex()
    {
        int nChilds = transform.parent.childCount;
        target = transform.parent.GetChild(nextTarget);
        if(nextTarget >= nChilds -1){
            nextTarget -= 1;
            foward = false;
        } else if(!foward && nextTarget > 1){
            nextTarget -= 1;
        } else if(!foward && nextTarget <= 1){
            nextTarget += 1;
            foward = true;
        } else if(foward){
            nextTarget += 1;
        }

    }

    // private void FixedUpdate()
    // {
    //     DampSpeed();
    // }

    // private void PerformMovement(float movementDirection)
    // {
    //     _player.Rigidbody.AddForce(Vector3.right * movementDirection * _speed, ForceMode.VelocityChange);
    // }

    // private void DampSpeed()
    // {
    //     float signal = (_player.Rigidbody.velocity.x > 0f)? 1f : -1f;

    //     if (Mathf.Abs(_player.Rigidbody.velocity.x) > _speed)
    //         _player.Rigidbody.velocity = new Vector3(_speed * signal, _player.Rigidbody.velocity.y, 0f);
    // }
}
