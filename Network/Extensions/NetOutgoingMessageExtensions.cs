using System;
using System.Collections.Generic;
using Lidgren.Network;
using Model;
using Model.Extensions;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Network.Extensions
{
    
    public static class NetOutgoingMessageExtensions
    {
        public static void Write<T>(this NetOutgoingMessage message, IEnumerable<T> list)
            where T : ISerializable, new()
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            int count = list.GetCount();
            message.Write(count);
            foreach (var entity in list)
            {
                entity.WritePayload(message);
            }
        }

        public static List<T> ReadList<T>(this NetIncomingMessage message)
            where T : ISerializable, new()
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var list = new List<T>(message.ReadInt32());
            for (int i = 0; i < list.Capacity; i++)
            {
                var entity = new T();
                entity.ReadPayload(message);
                list.Add(entity);
            }
            return list;
        }

        public static void Write(this NetOutgoingMessage message, DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
                dateTime = dateTime.ToUniversalTime();

            message.Write(dateTime.Ticks);
        }

        public static DateTime ReadDateTime(this NetIncomingMessage message)
        {
            return new DateTime(message.ReadInt64(), DateTimeKind.Utc);
        }

        public static void Write(this NetOutgoingMessage message, Image image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Bmp);
                message.Write(stream.Length);
                message.Write(stream.ToArray());
            }
        }

        public static Image ReadImage(this NetIncomingMessage message)
        {
            long streamSize = message.ReadInt64();
            byte[] imageData = message.ReadBytes((int)streamSize);
            using (MemoryStream stream = new MemoryStream(imageData))
            {
                return Image.FromStream(stream);
            }
        }

        public static void Write(this NetOutgoingMessage message, Protocol protocol)
        {
            if (protocol == null)
                throw new ArgumentNullException(nameof(protocol));

            message.Write(protocol.Id);
            message.Write(protocol.Version);
        }

        public static Protocol ReadProtocol(this NetIncomingMessage message)
        {
            return new Protocol(message.ReadByte(), message.ReadInt32());
        }

       
        public static void WriteProtocol(this NetOutgoingMessage message, Protocol protocol)
        {
            message.Write(protocol?.Id ?? 0);
            message.Write(protocol?.Version ?? 0);
        }
    }
}