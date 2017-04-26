using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace API.Generation {

    public static class Assert {

        public static void True<TException>(bool condition, Func<string> msg) where TException : Exception {
            if (!condition)
                Throw<TException>(msg());
        }

        public static void False<TException>(bool condition, Func<string> msg) where TException : Exception {
            True<TException>(!condition, msg);
        }

        public static IEnumerable<Type> CachedExceptionTypes {
            get {
                lock (LockObject) {
                    return EncounteredExceptionTypes.Keys.ToArray();
                }
            }
        }

        private static void Throw<TException>(string msg) where TException : Exception {
            ConstructorInfo info = null;
            lock (LockObject) {
                Type t = typeof(TException);
                if (EncounteredExceptionTypes.ContainsKey(t)) {
                    info = EncounteredExceptionTypes[t];
                }
                else {
                    info = t.GetConstructor(new[] { typeof(string) });
                    EncounteredExceptionTypes[t] = info;
                }
            }
            throw (info.Invoke(new[] { msg }) as TException);
        }

        private static Dictionary<Type, ConstructorInfo> EncounteredExceptionTypes { get; set; } = new Dictionary<Type, ConstructorInfo>();

        private static object LockObject = new object();

    }

}

