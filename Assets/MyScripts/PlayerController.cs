using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private float power = 5;
    private Vector2 moveVelocity;
    private Vector2 _playerRotation = Vector2.zero;
    private Animator _animator;
    public float healhPlayer = 10;
    public float manaPlayer = 70;
    public float armorPlayer = 5;
    public float ñapacityBagPlayer = 10;
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    public Transform startPosition;
    private TextMeshProUGUI healhText;
    private TextMeshProUGUI armorText;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        _animator = FindObjectOfType<Animator>();
        healhText = GameObject.Find("HealhText").GetComponent<TextMeshProUGUI>();
        armorText = GameObject.Find("ArmorText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * power;
        

        ResetRotation();

        if (Input.GetKey(KeyCode.W))
            _playerRotation.y = 1;
        if (Input.GetKey(KeyCode.A))
            _playerRotation.x = -1;
        if (Input.GetKey(KeyCode.S))
            _playerRotation.y = -1;
        if (Input.GetKey(KeyCode.D))
            _playerRotation.x = 1;

        if (Mathf.Approximately(_playerRotation.x, 0)
            && Mathf.Approximately(_playerRotation.y, 0))
        {
            _playerRotation.y = -1;
        }

        UpdateParams();
    }
    private void FixedUpdate()
    {
        playerRB.velocity = moveVelocity;   
    }
    private void ResetRotation()
    {
        _playerRotation.x = 0;
        _playerRotation.y = 0;
    }

    private void UpdateParams()
    {
        _animator.SetFloat(Horizontal, _playerRotation.x);
        _animator.SetFloat(Vertical, _playerRotation.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("ToRaid"))
       {
            SceneManager.LoadScene("Raid");
       }
       if (collision.gameObject.CompareTag("ToHome"))
        {
            SceneManager.LoadScene("House");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (armorPlayer > 0)
            {

                armorPlayer -= 1f;
            }
            else
            {
                healhPlayer--;
            }
            UpdateText();
            GameOverScreen();
            
        }

    }
    public void UpdateText()
    {
        healhText.SetText("Hp: " + healhPlayer);
        armorText.SetText("Armor: " + armorPlayer);
    }
    private void GameOverScreen()
    {
        if (healhPlayer<=0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    
}