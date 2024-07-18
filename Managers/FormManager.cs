using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Reflection.Emit;

namespace Managers
{
    public class FormFactory
    {
      
        public void Discover(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");

            var mtype = typeof(Form);
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
        
        public void Register(IEnumerable<KeyValuePair<Type, Func<Form>>> messageTypes)
        {
            RegisterTypesWithCtors(messageTypes, false);

        }
       
        public void Register(IEnumerable<Type> messageTypes)
        {
            RegisterTypes(messageTypes, false);
        }

        
        public virtual Form Create(Type form)
        {
            Func<Form> mCtor;
            if (!messageCtors.TryGetValue(form, out mCtor))
                return null;

            return mCtor();
        }

        private readonly ConcurrentDictionary<Type, Func<Form>> messageCtors = new ConcurrentDictionary<Type, Func<Form>>();

        private void RegisterTypes(IEnumerable<Type> messageTypes, bool ignoreDupes)
        {
            if (messageTypes == null)
                throw new ArgumentNullException("messageTypes");

            var mtype = typeof(Form);

            var types = new Dictionary<Type, Func<Form>>();
            foreach (var t in messageTypes)
            {
                if (!mtype.IsAssignableFrom(t))
                    throw new ArgumentException(String.Format("{0} is not an implementation of Message", t.Name), "messageTypes");
                if (mtype.IsGenericType || mtype.IsGenericTypeDefinition)
                    throw new ArgumentException(String.Format("{0} is a generic type which is unsupported", t.Name), "messageTypes");

                var plessCtor = t.GetConstructor(Type.EmptyTypes);
                if (plessCtor == null)
                    throw new ArgumentException(String.Format("{0} has no parameter-less constructor", t.Name), "messageTypes");

                var dplessCtor = new DynamicMethod("plessCtor", mtype, Type.EmptyTypes);
                var il = dplessCtor.GetILGenerator();
                il.Emit(OpCodes.Newobj, plessCtor);
                il.Emit(OpCodes.Ret);

                types.Add(t, (Func<Form>)dplessCtor.CreateDelegate(typeof(Func<Form>)));
            }

            RegisterTypesWithCtors(types, ignoreDupes);
        }

        private void RegisterTypesWithCtors(IEnumerable<KeyValuePair<Type, Func<Form>>> messageTypes, bool ignoreDupes)
        {
            if (messageTypes == null)
                throw new ArgumentNullException("messageTypes");

            var mtype = typeof(Form);

            foreach (var kvp in messageTypes)
            {
                if (!mtype.IsAssignableFrom(kvp.Key))
                    throw new ArgumentException(String.Format("{0} is not an implementation of Message", kvp.Key.Name), "messageTypes");
                if (kvp.Key.IsGenericType || kvp.Key.IsGenericTypeDefinition)
                    throw new ArgumentException(String.Format("{0} is a generic type which is unsupported", kvp.Key.Name), "messageTypes");

                var m = kvp.Value();

                if (!this.messageCtors.TryAdd(m.GetType(), kvp.Value))
                {
                    if (ignoreDupes)
                        continue;

                    throw new ArgumentException(String.Format("A message of type {0} has already been registered.", m.GetType()), "messageTypes");
                }
            }
        }
    }
}
