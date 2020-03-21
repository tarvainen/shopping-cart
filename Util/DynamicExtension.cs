using System.Reflection;

namespace ShoppingCart.Util
{
    public static class DynamicExtension
    {
        public static void Invoke(this object obj, string method, object[] arguments)
        {
            try
            {
                obj.GetType().InvokeMember(method,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
                    null, obj, arguments);
            }
            catch (TargetInvocationException e)
            {
                throw e.GetBaseException();
            }
        }
    }
}
