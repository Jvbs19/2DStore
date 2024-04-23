using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D _rigidbody;

    [SerializeField] float _speed;

    private Vector2 m_movementInput;

    private void FixedUpdate()
    {
        _rigidbody.velocity = m_movementInput * _speed;
    }

    private void OnMove(InputValue inputValue)
    {
        m_movementInput =  inputValue.Get<Vector2>();
    }
    private void OnInventory(InputValue inputValue)
    {
        InventoryBehaviour.Instance.OnOffInventory();
    }
    private void OnQuit(InputValue inputValue)
    {
        Application.Quit();
    }

}
