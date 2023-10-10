namespace Enemy
{
    public class HpEnemy : HpBase
    {
        private static HpEnemy _instance;

        public static HpEnemy Instance
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
    }
}
