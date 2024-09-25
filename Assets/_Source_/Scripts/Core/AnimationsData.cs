using UnityEngine;

public class AnimationsData
{
    public class Ball
    {
        public static int Idel = Animator.StringToHash(nameof(Idel));
        public static int Destroy = Animator.StringToHash(nameof(Destroy)); 
    }
}
