﻿using System;
using System.Threading.Tasks;

namespace FsgImg.Dds.Interfaces.IO
{
    public interface IDdsHeaderDxt10Writer : IDisposable
    {
        void Write(IDdsHeaderDxt10 ddsHeaderDxt10);
        Task WriteAsync(IDdsHeaderDxt10Writer ddsHeaderDxt10);
    }
}
