﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
#if !SAFE

#endif
#if NET_4
using System.Collections.Concurrent;
#endif

namespace Network
{
    public class MessageFactory
    {
#if !SAFE
      
        public void Discover(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            var mtype = typeof(Message);
            RegisterTypes(
                assembly.GetTypes().Where(
                    t => !t.IsGenericType && !t.IsGenericTypeDefinition && mtype.IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null),
                true);
        }

        public void Discover()
        {
            Discover(Assembly.GetCallingAssembly());
        }

      
        public void DiscoverFromAssemblyOf<T>()
        {
            Discover(typeof(T).Assembly);
        }
#endif

        /// <summary>
        /// Registers types with a method of construction.
        /// </summary>
        /// <param name="messageTypes">The types to register.</param>
        /// <exception cref="ArgumentNullException"><paramref name="messageTypes"/> or <paramref name="protocol"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="messageTypes"/> contains non-implementations of <see cref="Message"/>
        /// or <paramref name="messageTypes"/> contains duplicate <see cref="Message.MessageType"/>s.</exception>
        public void Register(IEnumerable<KeyValuePair<Type, Func<Message>>> messageTypes)
        {
            RegisterTypesWithCtors(messageTypes, false);
        }

#if !SAFE
        /// <summary>
        /// Registers <paramref name="messageTypes"/> with their parameter-less constructor.
        /// </summary>
        /// <param name="messageTypes">The types to register.</param>
        /// <exception cref="ArgumentNullException"><paramref name="messageTypes"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="messageTypes"/> contains a type that is not an implementation of <see cref="Message"/>,
        /// has no parameter-less constructor or contains duplicate <see cref="Message.MessageType"/>s.
        /// </exception>
        public void Register(IEnumerable<Type> messageTypes)
        {
            RegisterTypes(messageTypes, false);
        }
#endif

        /// <summary>
        /// Creates a new instance of the <paramref name="messageType"/>.
        /// </summary>
        /// <param name="messageType">The unique message identifier in the protocol for the desired message.</param>
        /// <returns>A new instance of the <paramref name="messageType"/>, or <c>null</c> if this type has not been registered.</returns>
        public Message Create(ushort messageType)
        {
            Func<Message> mCtor;
#if !NET_4
            lock (messageCtors)
#endif
            {
                if (!messageCtors.TryGetValue(messageType, out mCtor))
                    return null;
            }

            return mCtor();
        }

#if !NET_4
        private readonly Dictionary<ushort, Func<Message>> messageCtors = new Dictionary<ushort, Func<Message>>();
#else
            private readonly ConcurrentDictionary<ushort, Func<Message>> messageCtors = new ConcurrentDictionary<ushort, Func<Message>>();
#endif

#if !SAFE
        private void RegisterTypes(IEnumerable<Type> messageTypes, bool ignoreDupes)
        {
            if (messageTypes == null)
                throw new ArgumentNullException(nameof(messageTypes));

            var mtype = typeof(Message);

            var types = new Dictionary<Type, Func<Message>>();
            foreach (var t in messageTypes)
            {
                if (!mtype.IsAssignableFrom(t))
                    throw new ArgumentException($"{t.Name} is not an implementation of Message", nameof(messageTypes));
                if (mtype.IsGenericType || mtype.IsGenericTypeDefinition)
                    throw new ArgumentException($"{t.Name} is a generic type which is unsupported", nameof(messageTypes));

                var plessCtor = t.GetConstructor(Type.EmptyTypes);
                if (plessCtor == null)
                    throw new ArgumentException($"{t.Name} has no parameter-less constructor", nameof(messageTypes));

                var dplessCtor = new DynamicMethod("plessCtor", mtype, Type.EmptyTypes);
                var il = dplessCtor.GetILGenerator();
                il.Emit(OpCodes.Newobj, plessCtor);
                il.Emit(OpCodes.Ret);

                types.Add(t, (Func<Message>)dplessCtor.CreateDelegate(typeof(Func<Message>)));
            }

            RegisterTypesWithCtors(types, ignoreDupes);
        }
#endif

        private void RegisterTypesWithCtors(IEnumerable<KeyValuePair<Type, Func<Message>>> messageTypes, bool ignoreDupes)
        {
            if (messageTypes == null)
                throw new ArgumentNullException(nameof(messageTypes));

            var mtype = typeof(Message);

#if !NET_4
            lock (messageCtors)
#endif
            {
                foreach (var kvp in messageTypes)
                {
                    if (!mtype.IsAssignableFrom(kvp.Key))
                        throw new ArgumentException($"{kvp.Key.Name} is not an implementation of Message", nameof(messageTypes));
                    if (kvp.Key.IsGenericType || kvp.Key.IsGenericTypeDefinition)
                        throw new ArgumentException($"{kvp.Key.Name} is a generic type which is unsupported", nameof(messageTypes));

                    var m = kvp.Value();

#if !NET_4
                    if (messageCtors.ContainsKey(m.MessageType))
                    {
                        if (ignoreDupes)
                            continue;

                        throw new ArgumentException($"A message of type {m.MessageType} has already been registered.", nameof(messageTypes));
                    }

                    messageCtors.Add(m.MessageType, kvp.Value);
#else
                        if (!messageCtors.TryAdd(m.MessageType, kvp.Value))
                        {
                            if (ignoreDupes)
                                continue;

                            throw new ArgumentException($"A message of type {m.MessageType} has already been registered.", nameof(messageTypes));
                        }
#endif
                }
            }
        }
    }
}