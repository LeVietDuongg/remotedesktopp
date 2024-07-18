using System;
using System.Collections.Generic;
using System.Linq;

namespace Network
{
  
    public sealed class Protocol : MessageFactory, IEquatable<Protocol>
    {
        private readonly Dictionary<int, bool> compatible;

        public Protocol(byte id)
        {
            if (id == 1)
            {
                throw new ArgumentException("ID 1 is reserved for Tempest use.", nameof(id));
            }

            Id = id;
        }

        public Protocol(byte id, int version) : this(id)
        {
            Version = version;
        }

        public Protocol(byte id, int version, params int[] compatibleVersions) : this(id, version)
        {
            if (compatibleVersions == null)
            {
                throw new ArgumentNullException(nameof(compatibleVersions));
            }

            compatible = compatibleVersions.ToDictionary(v => v, v => true);
        }

        public int Version { get; private set; }
        public byte Id { get; internal set; }

        public bool CompatibleWith(int versionToCheck)
        {
            if (versionToCheck == Version)
            {
                return true;
            }

            if (compatible == null)
            {
                return false;
            }

            return compatible.ContainsKey(versionToCheck);
        }

        public bool CompatibleWith(Protocol protocol)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }

            if (Id != protocol.Id)
            {
                return false;
            }

            return CompatibleWith(protocol.Version);
        }

        public bool IsSameProtocolAs(Protocol protocol)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }

            return Id == protocol.Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Protocol);
        }

        public bool Equals(Protocol other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return GetType() == other.GetType() && other.Id == Id && Version == other.Version;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Version.GetHashCode() ^ GetType().GetHashCode();
        }

        public static bool operator ==(Protocol left, Protocol right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Protocol left, Protocol right)
        {
            return !Equals(left, right);
        }
    }
}