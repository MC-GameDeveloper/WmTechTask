using System;
using Pixelplacement;
using UnityEngine;

public static class Utilities
{
        public enum GameState
        {
                StartState = 0,
                GameState = 1,
                EndState = 2
        }
        
        public static void DamageAnimation(SpriteRenderer target, AnimationCurve animCurve)
        {
                Tween.Color(target, Color.white, Color.red, 2, 0, animCurve);
        }
}
