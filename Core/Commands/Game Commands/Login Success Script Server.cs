﻿using System;

namespace ProjectEternity.Core.Online
{
    public class LoginSuccessScriptServer : OnlineScript
    {
        public const string ScriptName = "Login Success";

        private readonly Player PlayerInfo;

        public LoginSuccessScriptServer(Player PlayerInfo)
            : base(ScriptName)
        {
            this.PlayerInfo = PlayerInfo;
        }

        public override OnlineScript Copy()
        {
            return null;
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            WriteBuffer.AppendString(PlayerInfo.ID);
            WriteBuffer.AppendString(PlayerInfo.Name);
        }

        protected internal override void Execute(IOnlineConnection ActivePlayer)
        {
        }

        protected internal override void Read(OnlineReader Sender)
        {
            throw new NotImplementedException();
        }
    }
}