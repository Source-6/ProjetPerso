using UnityEngine;


public class PlayerBehavior : MonoBehaviour
{
    #region old code
    // [SerializeField] private InputActionAsset actions;
    // private InputAction xAxis;
    // private InputAction zAxis;
    // [SerializeField] private float speed;
    // void Start()
    // {
    //     xAxis = actions.FindActionMap("PlayerMove").FindAction("xAxis");
    //     zAxis = actions.FindActionMap("PlayerMove").FindAction("zAxis");
    // }

    // void OnEnable()
    // {
    //     actions.FindActionMap("PlayerMove").Enable();
    // }
    // void OnDisable()
    // {
    //     actions.FindActionMap("PlayerMove").Disable();
    // }

    // void Update()
    // {
    //     PlayerMove();
    // }


    // void PlayerMove()
    // {
    //     float xMove = xAxis.ReadValue<float>();
    //     float zMove = zAxis.ReadValue<float>();

    //     Vector3 move = new Vector3(xMove,0f,zMove);
    //     Vector3 movement = speed * Time.deltaTime * move;
    //     transform.Translate(movement);
    // }
    #endregion

    [SerializeField] Transform startingPos;
    [SerializeField] EnemyBehavior enemy;
    [SerializeField] public int playerLife;

    public void Initialize()
    {
        transform.position = startingPos.position;
    }

    










}
