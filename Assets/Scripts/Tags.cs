using UnityEngine;

public class Tags
{
    public const string PLAYER = "Player";
    public const string GROUND = "Ground";
    public const string ENEMY = "Enemy";
    public const string GEM_TEXT = "Text Gems";
    public const string HEALTH_TEXT = "Text Health";
    public const string FPS_TEXT = "Text FPS";
}

public class AnimatorTags
{
    public static int startHash = Animator.StringToHash("Start");
    public static int verticalSpeedHash = Animator.StringToHash("VerticalSpeed");
    public static int groundedHash = Animator.StringToHash("Grounded");
    public static int jumpHash = Animator.StringToHash("Jump");
    public static int hurtHash = Animator.StringToHash("Hurt");
    public static int runHash = Animator.StringToHash("Run");
    public static int crouchHash = Animator.StringToHash("Crouch");
}
