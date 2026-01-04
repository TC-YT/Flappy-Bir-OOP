using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _flapForce = 5f;
    private bool _isAlive = true;

    [SerializeField] private float _yBounds = -5f;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }

        if (_isAlive && transform.position.y < _yBounds)
        {
            Die();
        }

        if (!GameManager.Instance.IsGameStarted()) return;
    }

    public void Flap()
    {
        if (_isAlive)
        {
            _rb2d.linearVelocity = Vector2.zero;
            _rb2d.linearVelocity = Vector2.up * _flapForce;
        }
    }

    public void Die()
    {
        if (!_isAlive) return; 
        _isAlive = false;
        Debug.Log("Get Gud Kid");
        GameManager.Instance.GameOver();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
}
