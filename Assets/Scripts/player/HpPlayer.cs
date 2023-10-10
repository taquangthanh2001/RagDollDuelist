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
    }
}