using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana1 : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("Attack");
        }
    }
}
