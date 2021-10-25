namespace Asteroids.Entities.Entities.Weapons.Weapons
{
    public class WeaponReloader
    {
        private readonly float _reloadedTimeTotal;
        private float _reloadedTimeCurrent;
        private bool _loaded;

        public bool Unloaded => !_loaded;

        public WeaponReloader(float reloadedTime)
        {
            _reloadedTimeTotal = reloadedTime;
        }

        public void StartReload()
        {
            _loaded = false;
            _reloadedTimeCurrent = _reloadedTimeTotal;
        }

        public void Countdown(float delta)
        {
            if (_loaded)
            {
                return;
            }
            if (_reloadedTimeCurrent > 0)
            {
                _reloadedTimeCurrent -= delta;
            }
            else
            {
                _loaded = true;
            }
        }
    }
}