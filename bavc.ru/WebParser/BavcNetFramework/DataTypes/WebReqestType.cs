﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParser.BavcNetFramework.DataTypes
{
    public enum WebRequestType
    {
        Http,
        Json,
    }

    public enum WebProxyType
    {
        Http,
        Sock4,
        Sock4a,
        Sock5
    }

    /// <summary>
    /// Типы для странниц
    /// </summary>
    public enum WebPageType
    {
        Main,
        Catalog
    }

    public enum WebPageStatus
    {
        New,
        Busy,
        Ok,
        Error,
        Unknow
    }
}
