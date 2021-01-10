using System;

namespace CatTower
{
    public class Message
    {
        private Action m_Listeners;

        public void AddListener(Action listener)
        {
            m_Listeners += listener;
        }

        public void RemoveListener(Action listener)
        {
            m_Listeners -= listener;
        }

        public void Send()
        {
            if (m_Listeners != null)
                m_Listeners();
        }
    }
}