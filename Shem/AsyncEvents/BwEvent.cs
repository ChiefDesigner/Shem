﻿using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class BwEvent : AsyncEvent
    {
        public BwEvent()
        {

        }

        public override AsyncEvents Event
        {
            get { return AsyncEvents.BW; }
        }

        protected override void ParseToEvent(Reply reply)
        {
            //TODO: Implement parsing
            throw new System.NotImplementedException();
        }
    }
}