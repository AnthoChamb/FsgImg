using FsgImg.Abstractions;
using FsgImg.Dds.Abstractions.Enums;
using FsgImg.Dds.Abstractions.Options;
using FsgImg.Dds.Converters;
using FsgImg.Dds.Factories;
using FsgImg.Factories;
using System.IO;
using System.Management.Automation;

namespace FsgImg.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.New, "FsgImgDds")]
    public class NewFsgImgDdsCommand : PSCmdlet
    {
        [Alias("PSPath")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] LiteralPath { get; set; }

        [Parameter(Position = 1)]
        public string Destination { get; set; }

        [Parameter]
        public DdsImgGame Game { get; set; } = DdsImgGame.ConsoleGhl;

        [Parameter(Mandatory = true)]
        public DdsImgPlatform Platform { get; set; }

        protected override void ProcessRecord()
        {
            var options = new ConvertDdsToImgOptions
            {
                Game = Game,
                Platform = Platform,
            };

            var readerFactory = new DdsStreamReaderFactory(new DdsHeaderStreamReaderFactory(new DdsHeaderByteArrayReaderFactory(new DdsPixelFormatByteArrayReaderFactory())),
                                                           new DdsHeaderDxt10StreamReaderFactory(new DdsHeaderDxt10ByteArrayReaderFactory()));
            var writerFactory = new ImgHeaderStreamWriterFactory(new ImgHeaderByteArrayWriterFactory());
            var converterFactory = new DdsToImgStreamConverterFactory(new DdsToImgHeaderConverter(new ImgHeaderFactory()),
                                                                      readerFactory,
                                                                      writerFactory,
                                                                      new ImgStreamFactory());

            foreach (var path in LiteralPath)
            {
                var providerPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(path);
                var dest = string.IsNullOrEmpty(Destination) ? Path.ChangeExtension(providerPath, ImgConstants.ImgExtension) : SessionState.Path.GetUnresolvedProviderPathFromPSPath(Destination);

                using (var inputStream = File.OpenRead(providerPath))
                using (var outputStream = File.Create(dest))
                using (var converter = converterFactory.Create(inputStream, outputStream, true))
                {
                    converter.Convert(options);
                }
            }
        }
    }
}
