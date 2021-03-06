﻿using System;
using System.Collections.Generic;

namespace ProjectEternity.Core.Online
{
    public class RoomListScriptServer : OnlineScript
    {
        public const string ScriptName = "Room List";

        private readonly Server Owner;
        private readonly ICollection<IRoomInformations> ListRoomUpdates;

        public RoomListScriptServer(Server Owner, ICollection<IRoomInformations> ListRoomUpdates)
            : base(ScriptName)
        {
            this.Owner = Owner;
            this.ListRoomUpdates = ListRoomUpdates;
        }

        public override OnlineScript Copy()
        {
            return new AskRoomListScriptServer(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            WriteBuffer.AppendInt32(ListRoomUpdates.Count);
            foreach (RoomInformations ActiveRoom in ListRoomUpdates)
            {
                WriteBuffer.AppendString(ActiveRoom.RoomID);
                WriteBuffer.AppendBoolean(ActiveRoom.IsDead);

                if (!ActiveRoom.IsDead)
                {
                    WriteBuffer.AppendString(ActiveRoom.RoomName);
                    WriteBuffer.AppendInt32(ActiveRoom.MaxNumberOfPlayer);
                    WriteBuffer.AppendInt32(ActiveRoom.CurrentPlayerCount);
                }
            }
        }

        protected internal override void Execute(IOnlineConnection ActivePlayer)
        {
            throw new NotImplementedException();
        }

        protected internal override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}
