﻿using Shem.Utils;

namespace Shem.AsyncEvents
{
    public enum AsyncEvents
    {
        [TypeValue(typeof(AddrMapEvent))]
        ADDRMAP,
        [TypeValue(typeof(AuthDirNewDescsEvent))]
        AUTHDIR_NEWDESCS,
        [TypeValue(typeof(BuildTimeoutSetEvent))]
        BUILDTIMEOUT_SET,
        [TypeValue(typeof(BwEvent))]
        BW,
        [TypeValue(typeof(CircEvent))]
        CIRC,
        [TypeValue(typeof(CircMinorEvent))]
        CIRC_MINOR,
        [TypeValue(typeof(ClientsSeenEvent))]
        CLIENTS_SEEN,
        [TypeValue(typeof(ConfChangedEvent))]
        CONF_CHANGED,
        [TypeValue(typeof(DebugEvent))]
        DEBUG,
        [TypeValue(typeof(DescChangedEvent))]
        DESCCHANGED,
        [TypeValue(typeof(ErrEvent))]
        ERR,
        [TypeValue(typeof(GuardEvent))]
        GUARD,
        [TypeValue(typeof(InfoEvent))]
        INFO,
        [TypeValue(typeof(NewConsensusEvent))]
        NEWCONSENSUS,
        [TypeValue(typeof(NewDescEvent))]
        NEWDESC,
        [TypeValue(typeof(NoticeEvent))]
        NOTICE,
        [TypeValue(typeof(NsEvent))]
        NS,
        [TypeValue(typeof(OrConnEvent))]
        ORCONN,
        [TypeValue(typeof(SignalEvent))]
        SIGNAL,
        [TypeValue(typeof(StatusClientEvent))]
        STATUS_CLIENT,
        [TypeValue(typeof(StatusGeneralEvent))]
        STATUS_GENERAL,
        [TypeValue(typeof(StatusServerEvent))]
        STATUS_SERVER,
        [TypeValue(typeof(StreamEvent))]
        STREAM,
        [TypeValue(typeof(StreamBwEvent))]
        STREAM_BW,
        [TypeValue(typeof(WarnEvent))]
        WARN,
        [TypeValue(typeof(StatusSeverEvent))]
        STATUS_SEVER
    }
}