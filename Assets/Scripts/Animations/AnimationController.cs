using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        // Prendo il componente Animator dall'oggetto che ha questo script
        m_animator = GetComponent<Animator>();

        // Setto il parametro CanIdle a true
        m_animator.SetBool("CanIdle", true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
