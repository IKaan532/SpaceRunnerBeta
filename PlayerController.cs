using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour, IObserver
{
    public float Speed = 8;
    public Animator Animator;
    public float SpeedMultiplier = 1.0f;
    public GameObject SlideSound;
    public bool IsRight=false,IsLeft=false;
    public bool IsMovingDone=false;

    private GameObject _slideSoundReferences;

    void Start()
    {
        Animator = GetComponent<Animator>();
        GameEvents.AddObserver(this);  
    }

    void OnDisable()
    {
        GameEvents.RemoveObserver(this);  
    }

    void Update()
    {
        if (GameEvents.IsGameStarted)  
        {
            SpeedMultiplier += Time.deltaTime * 0.01f; 
            HandleInput();  
            transform.Translate(0, 0, SpeedMultiplier * Speed * Time.deltaTime); 
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A) && !IsLeft && !IsMovingDone)
        {
            IsMovingDone = true;
            MovePlayer(-3);
            if (transform.position.x==0)
            {
                IsLeft = true;
            }
            IsRight = false;
        }

        if (Input.GetKeyDown(KeyCode.D) && !IsRight && !IsMovingDone)
        {
            IsMovingDone = true;
            MovePlayer(3);
            if (transform.position.x == 0)
            {
                IsRight = true;
            }
            IsLeft = false;
        }
    }

    private void MovePlayer(float direction)
    {
        _slideSoundReferences = Instantiate(SlideSound);
        transform.DOMoveX(transform.position.x + direction, 0.25f / SpeedMultiplier).SetEase(Ease.OutSine).OnComplete(
            () =>
            {
                IsMovingDone = false; 
                Destroy(_slideSoundReferences);
            });
    }

    public void OnGameStart()
    {
        Animator.SetBool("IsGameStart", true);
    }

    public void OnGameEnd()
    {
        Animator.SetBool("IsGameFinish", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            GameEvents.TriggerGameEnd();  
        }
        else if (other.CompareTag("Alien"))
        {
            GameEvents.TriggerGameEnd();  
            Animator.SetBool("CrushAliens", true);  
        }
    }
}
