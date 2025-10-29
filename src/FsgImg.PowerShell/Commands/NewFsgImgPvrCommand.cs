using FsgImg.Abstractions;
using FsgImg.Factories;
using FsgImg.Pvr.Converters;
using FsgImg.Pvr.Factories;
using System.IO;
using System.Management.Automation;

namespace FsgImg.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.New, "FsgImgPvr")]
    public class NewFsgImgPvrCommand : PSCmdlet
    {
        [Alias("PSPath")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] LiteralPath { get; set; }

        [Parameter(Position = 1)]
        public string Destination { get; set; }

        protected override void ProcessRecord()
        {
            var readerFactory = new PvrHeaderStreamReaderFactory(new PvrHeaderByteArrayReaderFactory());
            var writerFactory = new ImgHeaderStreamWriterFactory(new ImgHeaderByteArrayWriterFactory());
            var converterFactory = new PvrToImgStreamConverterFactory(new PvrHeaderToImgHeaderConverter(new ImgHeaderFactory()),
                                                                      readerFactory,
                                                                      writerFactory);

            foreach (var path in LiteralPath)
            {
                var providerPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(path);
                var dest = string.IsNullOrEmpty(Destination) ? Path.ChangeExtension(providerPath, ImgConstants.ImgExtension) : SessionState.Path.GetUnresolvedProviderPathFromPSPath(Destination);

                using (var inputStream = File.OpenRead(providerPath))
                using (var outputStream = File.Create(dest))
                using (var converter = converterFactory.Create(inputStream, outputStream, true))
                {
                    converter.ConvertFrom();
                }
            }
        }
    }
}
