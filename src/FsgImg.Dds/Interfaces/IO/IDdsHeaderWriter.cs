﻿using System;
using System.Threading.Tasks;

namespace FsgImg.Dds.Interfaces.IO
{
    public interface IDdsHeaderWriter : IDisposable
    {
        void Write(IDdsHeader ddsHeader);
        Task WriteAsync(IDdsHeader ddsHeader);
    }
}
