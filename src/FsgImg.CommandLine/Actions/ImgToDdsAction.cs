using FsgImg.Dds.Abstractions;
using FsgImg.Dds.Abstractions.Enums;
using FsgImg.Dds.Abstractions.Options;
using FsgImg.Dds.Converters;
using FsgImg.Dds.Factories;
using FsgImg.Factories;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FsgImg.CommandLine.Actions
{
    public class ImgToDdsAction : AsynchronousCommandLineAction
    {
        private readonly Argument<FileInfo> _inputArgument;
        private readonly Option<FileInfo> _outputOption;
        private readonly Option<DdsImgPlatform?> _platformOption;

        public ImgToDdsAction(Argument<FileInfo> inputArgument, Option<FileInfo> outputOption, Option<DdsImgPlatform?> platformOption)
        {
            _inputArgument = inputArgument;
            _outputOption = outputOption;
            _platformOption = platformOption;
        }

        public override async Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = default)
        {
            var input = parseResult.GetRequiredValue(_inputArgument);
            var output = parseResult.GetValue(_outputOption) ?? new FileInfo(Path.ChangeExtension(input.FullName, DdsConstants.DdsExtension));
            var platform = parseResult.GetValue(_platformOption);

            var options = new ConvertImgToDdsOptions
            {
                Platform = platform,
            };

            var readerFactory = new ImgHeaderStreamReaderFactory(new ImgHeaderByteArrayReaderFactory(new ImgHeaderFactory()));
            var writerFactory = new DdsStreamWriterFactory(new DdsHeaderStreamWriterFactory(new DdsHeaderByteArrayWriterFactory(new DdsPixelFormatByteArrayWriterFactory())),
                                                           new DdsHeaderDxt10StreamWriterFactory(new DdsHeaderDxt10ByteArrayWriterFactory()));
            var converterFactory = new ImgToDdsStreamConverterFactory(new ImgHeaderToDdsConverter(new TextureFactory()),
                                                                      readerFactory,
                                                                      writerFactory,
                                                                      new ImgStreamFactory());

            using (var inputStream = input.OpenRead())
            using (var outputStream = output.Create())
            using (var converter = converterFactory.Create(inputStream, outputStream, true))
            {
                await converter.ConvertAsync(options, cancellationToken);
            }

            return 0;
        }
    }
}
