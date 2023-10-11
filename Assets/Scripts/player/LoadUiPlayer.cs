using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class LoadUiPlayer : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer imgFace;
        [SerializeField] protected SpriteRenderer imgBody;
        [SerializeField] protected SpriteRenderer imgHip;
        [SerializeField] protected SpriteRenderer imgHandR1;
        [SerializeField] protected SpriteRenderer imgHandR2;
        [SerializeField] protected SpriteRenderer imgHandL1;
        [SerializeField] protected SpriteRenderer imgHandL2;
        [SerializeField] protected SpriteRenderer imgLegR1;
        [SerializeField] protected SpriteRenderer imgLegR2;
        [SerializeField] protected SpriteRenderer imgLegL1;
        [SerializeField] protected SpriteRenderer imgLegL2;

        private void Start()
        {
        }
    }
}