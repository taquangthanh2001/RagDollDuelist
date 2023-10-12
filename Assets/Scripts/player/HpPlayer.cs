using Base;
using UnityEngine;
using Utils;

namespace Player
{
    public class HpPlayer : HpBase
    {
        private static HpPlayer _instance;

        protected GameObject endGameObj = null;

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
            if (endGameObj != null) return;
            StatusInGame.Status = StatusGame.Pause;
            endGameObj = UiBase.Instance.ShowPrefab(GameConst.EndGame);
            endGameObj.GetComponent<EndGame>().SetStatus(StatusGame.Lose);
        }
    }
}