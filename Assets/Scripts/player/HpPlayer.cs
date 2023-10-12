using Base;
using UnityEngine;
using Utils;

namespace Player
{
    public class HpPlayer : HpBase
    {
        private static HpPlayer _instance;

        public static HpPlayer Instance
        {
            get => _instance;
            private set => _instance = value;
        }

        protected override void Start()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            base.Start();
        }

        internal override void HpBar(float hpLost)
        {
            base.HpBar(hpLost);
            if (!(currentHp < 1)) return;
            var obj = UiBase.Instance.ShowPrefab(GameConst.EndGame);
            obj.GetComponent<EndGame>().SetStatus(StatusGame.Lose);
        }
    }
}