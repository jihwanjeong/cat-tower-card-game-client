using System;

namespace CatTower
{
    [Serializable]
    public class RoomInfoRequest
    {
        public string hostId;
        public string name;
        public int capacity;
        public int mode;
    }

    [Serializable]
    public class RoomInfoResponse
    {
        
    }
}