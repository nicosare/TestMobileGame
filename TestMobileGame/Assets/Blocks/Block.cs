using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool OnField => transform.parent.IsChildOf(GameObject.Find("Field").transform);
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void StartDestroyAnimation()
    {
        animator.SetTrigger("Play");
    }

    public void DestroyBlock()
    {
        Destroy(transform.gameObject);
        FieldSettings.OpenEventWindow("онаедю");
    }
}
