﻿using UnityEngine;
using UnityEngine.Events;

namespace Project_Setup.So_EventSystem.Generic
{
    public abstract class BaseGameEventListener<TGameEvent>
        : MonoBehaviour, IGameEventListener
        where TGameEvent : IGameEvent
    {
        [SerializeField]
        [Tooltip("Game event to listen to which will trigger the onGameEvent event")]
        private TGameEvent gameEvent = default;

        [SerializeField]
        [Tooltip("Called when the listener is triggered with an argument")]
        private UnityEvent onGameEvent = default;

        /// <summary>
        ///     Get or set the underlying GameEvent.
        /// </summary>
        public TGameEvent GameEvent
        {
            get => gameEvent;
            set => gameEvent = value;
        }

        /// <summary>
        ///     Get or set the underlying UnityEvent.
        /// </summary>
        public UnityEvent OnGameEvent
        {
            get => onGameEvent;
            set => onGameEvent = value;
        }

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            onGameEvent.Invoke();
        }
    }
}