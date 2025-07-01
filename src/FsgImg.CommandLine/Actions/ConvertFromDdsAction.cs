using FsgImg.Abstractions;
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
    public class ConvertFromDdsAction : AsynchronousCommandLineAction
    {
        private readonly Argument<FileInfo> _inputArgument;
        private readonly Option<FileInfo> _outputOption;
        private readonly Option<DdsImgGame> _gameOption;
        private readonly Option<DdsImgPlatform> _platformOption;

        public ConvertFromDdsAction(Argument<FileInfo> inputArgument, Option<FileInfo> outputOption, Option<DdsImgGame> gameOption, Option<DdsImgPlatform> platformOption)
        {
            _inputArgument = inputArgument;
            _outputOption = outputOption;
            _gameOption = gameOption;
            _platformOption = platformOption;
        }

        public override async Task<int> InvokeAsync(ParseResult parseResult, CancellationToken cancellationToken = default)
        {
            var input = parseResult.GetRequiredValue(_inputArgument);
            var output = parseResult.GetValue(_outputOption) ?? new FileInfo(Path.ChangeExtension(input.FullName, ImgConstants.ImgExtension));
            var game = parseResult.GetRequiredValue(_gameOption);
            var platform = parseResult.GetRequiredValue(_platformOption);

            var options = new ConvertFromOptions
            {
                Game = game,
                Platform = platform,
            };

            var readerFactory = new DdsStreamReaderFactory(new DdsHeaderStreamReaderFactory(new DdsHeaderBufferReaderFactory(new DdsPixelFormatBufferReaderFactory())),
                                                           new DdsHeaderDxt10StreamReaderFactory(new DdsHeaderDxt10BufferReaderFactory()));
            var writerFactory = new ImgHeaderStreamWriterFactory(new ImgHeaderBufferWriterFactory());
            var converterFactory = new DdsToImgStreamConverterFactory(new DdsToImgHeaderConverter(new ImgHeaderFactory()),
                                                                      readerFactory,
                                                                      writerFactory,
                                                                      new ImgStreamFactory());

            using (var inputStream = input.OpenRead())
            using (var outputStream = output.Create())
            using (var converter = converterFactory.Create(inputStream, outputStream, true))
            {
                await converter.ConvertFromAsync(options, cancellationToken);
            }

            return 0;
        }
    }
}
