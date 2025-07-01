using FsgImg.Dds.Abstractions;
using FsgImg.Dds.Abstractions.Enums;
using FsgImg.Dds.Abstractions.Options;
using FsgImg.Dds.Converters;
using FsgImg.Dds.Factories;
using FsgImg.Factories;
using System.IO;
using System.Management.Automation;

namespace FsgImg.PowerShell.Commands
{
    [Cmdlet(VerbsData.ConvertTo, "FsgImgDds")]
    public class ConvertToFsgImgDdsCommand : PSCmdlet
    {
        [Alias("PSPath")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] LiteralPath { get; set; }

        [Parameter(Position = 1)]
        public string Destination { get; set; }

        [Parameter]
        public DdsImgPlatform? Platform { get; set; }

        protected override void ProcessRecord()
        {
            var options = new ConvertToOptions
            {
                Platform = Platform,
            };

            var readerFactory = new ImgHeaderStreamReaderFactory(new ImgHeaderBufferReaderFactory(new ImgHeaderFactory()));
            var writerFactory = new DdsStreamWriterFactory(new DdsHeaderStreamWriterFactory(new DdsHeaderBufferWriterFactory(new DdsPixelFormatBufferWriterFactory())),
                                                           new DdsHeaderDxt10StreamWriterFactory(new DdsHeaderDxt10BufferWriterFactory()));
            var converterFactory = new ImgToDdsStreamConverterFactory(new ImgHeaderToDdsConverter(new TextureFactory()),
                                                                      readerFactory,
                                                                      writerFactory,
                                                                      new ImgStreamFactory());

            foreach (var path in LiteralPath)
            {
                var providerPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(path);
                var dest = string.IsNullOrEmpty(Destination) ? Path.ChangeExtension(providerPath, DdsConstants.DdsExtension) : SessionState.Path.GetUnresolvedProviderPathFromPSPath(Destination);

                using (var inputStream = File.OpenRead(providerPath))
                using (var outputStream = File.Create(dest))
                using (var converter = converterFactory.Create(inputStream, outputStream, true))
                {
                    converter.ConvertTo(options);
                }
            }
        }
    }
}
