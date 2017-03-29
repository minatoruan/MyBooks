using System;
using MyBooks.Model.Entities;

namespace MyBooks.Model.Extensions
{
    public static class TermBalanceExtenssion
    {
        private static DateTime GetDateByTermStr(TermBalance @this, int day)
        {
            var year = int.Parse(@this.Term.Substring(0, 4));
            var month = int.Parse(@this.Term.Substring(4, 2));
            return new DateTime(year, month, day);
        }

        public static DateTime StartDate(this TermBalance @this)
        {
            return GetDateByTermStr(@this, 23);
        }

        public static DateTime EndDate(this TermBalance @this)
        {
            return GetDateByTermStr(@this, 22);
        }
    }
}
