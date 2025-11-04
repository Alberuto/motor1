using UnityEngine;
using UnityEngine.InputSystem;

public class nivel2 : MonoBehaviour{

    [Header("Ajustes")]
    public float moveSpeed;
    public SpriteRenderer spriteRenderer;
    public BaseFacing baseFacing = BaseFacing.Right;
    [Range(-180, 180)] public float rotationOffset = 0f;

    private Rigidbody2D rb;
    private Transform visual;
    private Vector2 move, lastDir = Vector2.up;
    private const float EPS = 0.01f;

    public enum BaseFacing { Right, Left, Up, Down }

    private void Awake(){

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        if (!spriteRenderer)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        visual = spriteRenderer ? spriteRenderer.transform : transform;

    }
    public void OnMove(InputValue value) {
        move = value.Get<Vector2>();
    }
    private void FixedUpdate(){

        Vector2 dir = move.sqrMagnitude > 1f ? move.normalized : move;
        rb.linearVelocity = dir * moveSpeed;
    }
    void Update(){

        Vector2 look = move.sqrMagnitude >= EPS ? move : rb.linearVelocity;

        if (look.sqrMagnitude >= EPS)
            lastDir = Snap4(look);

        float angle = AngleFromDir(lastDir) - BaseFacingToAngle(baseFacing) + rotationOffset;
        visual.localRotation= Quaternion.Euler(0f, 0f, angle);
    }
    static Vector2 Snap4(Vector2 v) {

        return Mathf.Abs(v.x) > Mathf.Abs(v.y) ? new Vector2(Mathf.Sign(v.x), 0f) : new Vector2 (0f, Mathf.Sign(v.y));
    }
    static float AngleFromDir(Vector2 v) {

        if (v.x > 0) return 0f;
        if (v.x < 0) return 180f;
        if (v.y > 0) return 90f;
        return 270f;
    }
    static float BaseFacingToAngle(BaseFacing baseJugador) { 

        return baseJugador == BaseFacing.Right ? 0f 
            : baseJugador == BaseFacing.Up ? 90f
            : baseJugador == BaseFacing.Left ? 180f
            : 270f;

        return 0f;
    }
}