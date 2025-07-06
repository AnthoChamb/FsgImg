using FsgImg.Pvr.Abstractions;
using FsgImg.Pvr.Factories;
using System.IO;
using System.Management.Automation;

namespace FsgImg.PowerShell.Commands
{
    [Cmdlet(VerbsData.ConvertTo, "FsgImgPvr")]
    public class ConvertToFsgImgPvrCommand : PSCmdlet
    {
        [Alias("PSPath")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] LiteralPath { get; set; }

        [Parameter(Position = 1)]
        public string Destination { get; set; }

        protected override void ProcessRecord()
        {
            var converterFactory = new ImgToPvrStreamConverterFactory();

            foreach (var path in LiteralPath)
            {
                var providerPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(path);
                var dest = string.IsNullOrEmpty(Destination) ? Path.ChangeExtension(providerPath, PvrConstants.PvrExtension) : SessionState.Path.GetUnresolvedProviderPathFromPSPath(Destination);

                using (var inputStream = File.OpenRead(providerPath))
                using (var outputStream = File.Create(dest))
                using (var converter = converterFactory.Create(inputStream, outputStream, true))
                {
                    converter.ConvertTo();
                }
            }
        }
    }
}
