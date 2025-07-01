using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.Converters;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Converters;
using System.IO;

namespace FsgImg.Dds.Factories
{
    public class DdsToImgStreamConverterFactory : IDdsToImgStreamConverterFactory
    {
        private readonly IDdsToImgHeaderConverter _converter;
        private readonly IDdsStreamReaderFactory _readerFactory;
        private readonly IImgHeaderStreamWriterFactory _writerFactory;
        private readonly IImgStreamFactory _imgStreamFactory;

        public DdsToImgStreamConverterFactory(IDdsToImgHeaderConverter converter,
                                              IDdsStreamReaderFactory readerFactory,
                                              IImgHeaderStreamWriterFactory writerFactory,
                                              IImgStreamFactory imgStreamFactory)
        {
            _converter = converter;
            _readerFactory = readerFactory;
            _writerFactory = writerFactory;
            _imgStreamFactory = imgStreamFactory;
        }

        public IDdsToImgConverter Create(Stream inputStream, Stream outputStream, bool leaveOpen)
        {
            return new DdsToImgStreamConverter(inputStream,
                                               outputStream,
                                               _converter,
                                               _readerFactory,
                                               _writerFactory,
                                               _imgStreamFactory,
                                               leaveOpen);
        }
    }
}
