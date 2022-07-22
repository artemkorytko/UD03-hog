using System;
using System.Net.Security;
using UnityEngine;

namespace Moba
{
    public enum PlayerType
    {
        None = -1,
        MailPlayer,
        Enemy,
        bot
    }

    public abstract class BasePlayer : MonoBehaviour
    {
        [SerializeField] private PlayerType _type;
        [SerializeField] private int _maxHealth;
        private int _currentHealth;
        private bool _isActive;

        public bool IsAlive => _currentHealth > 0;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        private void Update()
        {
            if (!_isActive)
        }
        return;
    }

    BeActive();
}

protected abstract void BeActive();