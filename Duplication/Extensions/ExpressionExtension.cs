using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Duplication.Extensions
{
    public static class ExpressionExtension
    {
        public static PropertyInfo GetPropertyInfo<T1, T2>(this Expression<Func<T1, T2>> propertySelector)
        {
            var body = propertySelector.Body as MemberExpression;
            if (body != null)
            {
                return (PropertyInfo)body.Member;
            }

            var body2 = propertySelector.Body as UnaryExpression;
            if (body2 != null)
            {
                return (PropertyInfo)((MemberExpression)body2.Operand).Member;
            }

            throw new NotSupportedException();
        }
    }
}
