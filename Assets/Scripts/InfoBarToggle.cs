using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBarToggle : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private bool isOpen = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Toggle()
    {
        if (isOpen)
        {
            //Close it
            PlayAnimationBox(false);
        }
        else
        {
            //Open it
            PlayAnimationBox(true);
        }
    }

    private void PlayAnimationBox(bool _result)
    {
        _animator.SetBool("Show", _result);
        isOpen = _result;
    }
}
