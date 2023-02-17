using Pixelplacement;
using UnityEngine;

public static class Utilities
{
        public static void DamageAnimation(SpriteRenderer target, AnimationCurve animCurve)
        {
                Tween.Color(target, Color.white, Color.red, 2, 0, animCurve);
        }
}
