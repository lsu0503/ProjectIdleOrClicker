using System;
using UnityEngine;

public class Player: MonoBehaviour
{
    public PlayerStatus status { get; private set; }
    public Vector3 position { get; private set; }
    public Rigidbody rigid { get; private set; }
    public Animator animator { get; private set; }
    public PlayerInfoUI infoUI { get; private set; }

    private PlayerStateMachine stateMachine;

    public event Action<float> TimeCheckEvent;

    private void Awake()
    {
        status = GetComponent<PlayerStatus>();
        rigid = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        stateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
        infoUI = UIManager.Instance.playerCharacterListUI.AddInfoUI(this);
        animator.runtimeAnimatorController = status.data.animator;
    }

    private void FixedUpdate()
    {
        CallTimeCheckEvent(Time.deltaTime);
    }

    public void SetPosition(Vector3 _position)
    {
        position = _position;
    }

    public void CallTimeCheckEvent(float _timeCheck)
    {
        TimeCheckEvent?.Invoke(_timeCheck);
    }
}