using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private bool _facingRight = true;
    private float _inputHorizontal;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");

        _animator.SetFloat("Speed", Mathf.Abs(movement));

        transform.position += new Vector3(movement, 0, 0) * _speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        _inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (_inputHorizontal > 0 && !_facingRight)
        {
            Flip();
        }

        if (_inputHorizontal < 0 && _facingRight)
        {
            Flip();
        }

        void Flip()
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;

            _facingRight = !_facingRight;
        }
    }
}