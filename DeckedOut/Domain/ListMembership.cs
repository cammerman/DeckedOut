using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckedOut.Domain
{
    [Serializable]
    public class ListMembership
    {
        public virtual EListType ListType { get; set; }
        public virtual int Index { get; set; }
    }
}