using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour {
    public float RunSpeed;

    Transform mTransform;
    Animator anim;
    Vector3 worldTargetPosition;

    void Start()
    {
        mTransform = transform;
        anim = GetComponentInChildren<Animator>();
    }

    void MoveTowards(Vector3 worldPosition)
    {
        anim.SetFloat(Animator.StringToHash("Speed"), 1);
        worldTargetPosition = worldPosition;
        mTransform.LookAt(worldPosition);
        Debug.Log(mTransform.forward);
    }

    void Stop()
    {
        //worldTargetPosition = null;
        anim.SetFloat(Animator.StringToHash("Speed"), 0);
    }

    void Update()
    {
        if (worldTargetPosition != null)
        {
            mTransform.position = Vector3.MoveTowards(mTransform.position, worldTargetPosition, Time.deltaTime * RunSpeed);
            if (mTransform.position == worldTargetPosition)
                Stop();
        }
    }
}
