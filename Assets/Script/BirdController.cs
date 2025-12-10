using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BirdController : MonoBehaviour
{
    // ENCAPSULATION: Data internal disembunyikan (private) dari script lain
    private Rigidbody2D _rb2d;
    private float _flapForce = 5f;
    private bool _isAlive = true;

    // Batas Y di bawah layar untuk Game Over
    [SerializeField] private float _yBounds = -5f;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mendeteksi Input (klik mouse kiri, tap, atau tombol Spasi)
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }

        // Pengecekan posisi Y untuk Game Over
        if (_isAlive && transform.position.y < _yBounds)
        {
            Die();
        }
    }

    // ENCAPSULATION: Method publik untuk aksi yang aman
    public void Flap()
    {
        if (_isAlive)
        {
            // Set kecepatan vertikal saat ini menjadi nol dulu agar flap konsisten
            _rb2d.linearVelocity = Vector2.zero;
            // Berikan kecepatan instan ke atas sebesar _flapForce
            _rb2d.linearVelocity = Vector2.up * _flapForce;
        }
    }

    // Method Kondisi Kalah: Dipanggil oleh Pipa/Lantai
    public void Die()
    {
        if (!_isAlive) return; // Mencegah double die
        _isAlive = false;
        Debug.Log("Get Gud Kid");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Jika terjadi tabrakan, panggil method kalah
        Die();
    }
}
