using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Pvr.Abstractions.Interfaces.Converters;
using FsgImg.Pvr.Abstractions.Interfaces.Factories;
using FsgImg.Pvr.Converters;
using System.IO;

namespace FsgImg.Pvr.Factories
{
    public class PvrToImgStreamConverterFactory : IPvrToImgStreamConverterFactory
    {
        private readonly IPvrHeaderToImgHeaderConverter _converter;
        private readonly IPvrHeaderStreamReaderFactory _readerFactory;
        private readonly IImgHeaderStreamWriterFactory _writerFactory;

        public PvrToImgStreamConverterFactory(IPvrHeaderToImgHeaderConverter converter, IPvrHeaderStreamReaderFactory readerFactory, IImgHeaderStreamWriterFactory writerFactory)
        {
            _converter = converter;
            _readerFactory = readerFactory;
            _writerFactory = writerFactory;
        }

        public IPvrToImgConverter Create(Stream inputStream, Stream outputStream, bool leaveOpen)
        {
            return new PvrToImgStreamConverter(inputStream, outputStream, _converter, _readerFactory, _writerFactory, leaveOpen);
        }
    }
}
