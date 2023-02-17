using Pixelplacement;
using UnityEngine;

public static class Utilities
{
        public static void DamageAnimation(SpriteRenderer target, AnimationCurve animCurve)
        {
                Debug.Log("DamageAnimation");
                Tween.Color(target, target.color, Color.red, 2, 0, animCurve);
        }
}
