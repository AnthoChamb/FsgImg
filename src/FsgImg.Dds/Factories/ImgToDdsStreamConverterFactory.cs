using FsgImg.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Abstractions.Interfaces.Converters;
using FsgImg.Dds.Abstractions.Interfaces.Factories;
using FsgImg.Dds.Converters;
using System.IO;

namespace FsgImg.Dds.Factories
{
    public class ImgToDdsStreamConverterFactory : IImgToDdsStreamConverterFactory
    {
        private readonly IImgHeaderToDdsConverter _converter;
        private readonly IImgHeaderStreamReaderFactory _readerFactory;
        private readonly IDdsStreamWriterFactory _writerFactory;
        private readonly IImgStreamFactory _imgStreamFactory;

        public ImgToDdsStreamConverterFactory(IImgHeaderToDdsConverter converter,
                                              IImgHeaderStreamReaderFactory readerFactory,
                                              IDdsStreamWriterFactory writerFactory,
                                              IImgStreamFactory imgStreamFactory)
        {
            _converter = converter;
            _readerFactory = readerFactory;
            _writerFactory = writerFactory;
            _imgStreamFactory = imgStreamFactory;
        }

        public IImgToDdsConverter Create(Stream inputStream, Stream outputStream, bool leaveOpen)
        {
            return new ImgToDdsStreamConverter(inputStream,
                                               outputStream,
                                               _converter,
                                               _readerFactory,
                                               _writerFactory,
                                               _imgStreamFactory,
                                               leaveOpen);
        }
    }
}
