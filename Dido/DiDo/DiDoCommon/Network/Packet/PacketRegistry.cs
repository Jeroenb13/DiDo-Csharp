using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DiDoCommon.Network.Packet
{
    class PacketRegistry
    {
        private static readonly Dictionary<ushort, Type> types = new Dictionary<ushort, Type>();

        static PacketRegistry() {
            RegisterPacket(1, typeof(PacketPlayerLogin));
        }

        private static void RegisterPacket(ushort id, Type type)
        {
            types.Add(id, type);
        }

        public static AbstractPacket CreateInstance(ushort id)
        {
            if (!types.ContainsKey(id))
            {
                return null;
            }

            try
            {
                Type type = types[id];
                ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
                return (AbstractPacket)ctor.Invoke(new object[0]);
            }catch(Exception e)
            {
                return null;
            }
        }
    }
}
