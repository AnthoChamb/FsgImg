﻿using FsgImg.Abstractions.Interfaces;

namespace FsgImg.Dds.Abstractions.Interfaces.Converters
{
    public interface IImgHeaderToDdsConverter
    {
        IDds ConvertTo(IImgHeader imgHeader);
    }
}
