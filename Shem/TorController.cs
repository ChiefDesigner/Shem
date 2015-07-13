﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shem.AsyncEvents;
using Shem.Commands;
using Shem.Exceptions;
using Shem.Replies;
using Shem.Utils;

namespace Shem
{
    public class TorController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public event Action<AsyncEvent> OnAsyncEvents;

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<AsyncEvents.AsyncEvents, ListableEvents<AsyncEvent>> OnAsyncEvent = new Dictionary<AsyncEvents.AsyncEvents, ListableEvents<AsyncEvent>>();

        /// <summary>
        /// This is true if we are Authenticated, false if
        /// the authentication failed or you haven't tried
        /// to authenticate yet.
        /// </summary>
        public bool Authenticated { get; private set; }

        /// <summary>
        /// Create a new tor controller, used for control tor
        /// through the control port.
        /// </summary>
        /// <param name="address">The address where you want to connect</param>
        /// <param name="port">The port where the control port is binded</param>
        /// <param name="connect">If this is true the controller will connect automatically to the server after initialization.</param>
        public TorController(string address = "127.0.0.1", uint port = 9051, bool connect = true) : base(address, port, connect) { }

        /// <summary>
        /// Authenticate with the tor control port.
        /// </summary>
        /// <param name="password">The tor control password NOT-hashed.</param>
        /// <returns>True in case of successful authentication, false in every other case.</returns>
        public bool Authenticate(string password = "")
        {
            if (!this.controlSocket.Connected)
                throw new SocketNotConnectedException();

            AuthenticateReply reply;
            List<Reply> replies;

            replies = SendCommand(new Authenticate(password));
            if (replies.Count < 1)
                return false;

            reply = new AuthenticateReply(replies[0]);
            this.Authenticated = reply.IsAuthenticated();
            Logger.LogInfo(Authenticated ? "Authentication succeded" : "Authentication failed");
            return Authenticated;
        }

        public void GetInfo()
        {
            // TODO: gonna do this sheet.
        }

        protected override void AsyncEventDispatcher(List<AsyncEvent> asyncEvents)
        {
            Task.Run(() =>
            {
                foreach (var e in asyncEvents)
                {
                    if (OnAsyncEvents != null)
                    {
                        OnAsyncEvents.Invoke(e);
                    }
                    if (OnAsyncEvent.ContainsKey(e.Event))
                    {
                        OnAsyncEvent[e.Event].Dispatch(e);
                    }
                }
            });
        }

        protected override void AsyncEventDispatcher(AsyncEvent asyncEvent)
        {
            AsyncEventDispatcher(new List<AsyncEvent>() { asyncEvent });
        }

        /// <summary>
        /// Close the connection with the control port.
        /// </summary>
        public override void Close()
        {
            base.Close();
        }
    }
}
