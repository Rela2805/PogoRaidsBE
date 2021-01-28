using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace PogoRaidsBackend.Helpers
{
    public interface INHibernateHelper
    {
        ISession OpenSession();
    }
}
