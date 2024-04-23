using UnityEngine;
using UnityEngine.InputSystem;

public class InteractiveAction : MonoBehaviour
{
    const string PLAYER_TAG = "Player";

    [SerializeField] PlayerInput _input;

    protected bool m_isActionPossible;

    private void Awake()
    {
        _input = new PlayerInput();
        _input.Enable();
    }
    public virtual void DoAction(InputAction.CallbackContext obj)
    {
        Debug.Log("Basic Interaction");
    }
    private void OnEnable()
    {
        _input.Player.Interact.performed += DoAction;
    }
    private void OnDisable()
    {
        _input.Player.Interact.performed -= DoAction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
            m_isActionPossible = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
            m_isActionPossible = false;
    }

}
