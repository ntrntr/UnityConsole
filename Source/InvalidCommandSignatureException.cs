﻿using System;
using System.Reflection;
using System.Runtime.Serialization;
using CSharpDocumentation;

namespace UnityConsole
{
    [Summary("An exception thrown when a static command has an invalid method signature")]
    [Serializable]
    public class InvalidCommandSignatureException : Exception
    {
        [Summary("The command with the invalid method signature.")]
        public MethodInfo command { get; private set; }

        public InvalidCommandSignatureException() : base() { }

        public InvalidCommandSignatureException(string message) : base(message) { }

        public InvalidCommandSignatureException(string message, MethodInfo command) : base(message)
        {
            this.command = command;
        }

        protected InvalidCommandSignatureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info != null)
                this.command = (MethodInfo) info.GetValue("command", typeof(MethodInfo));
        }

        // Perform serialization
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
                info.AddValue("command", command, typeof(MethodInfo));
        }
    }
}
