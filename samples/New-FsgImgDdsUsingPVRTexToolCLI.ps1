param(
    [Alias("PSPath", "i")]
    [Parameter(Mandatory, Position = 0, ValueFromPipeline, ValueFromPipelineByPropertyName)]
    [string[]]$LiteralPath,

    [Alias("o")]
    [Parameter(Position = 1)]
    [string]$Destination,

    [Parameter(Position = 2, ValueFromRemainingArguments)]
    [string[]]$Remaining,

    [Parameter()]
    [FsgImg.Dds.Abstractions.Enums.DdsImgGame]$Game = [FsgImg.Dds.Abstractions.Enums.DdsImgGame]::ConsoleGhl,

    [Parameter(Mandatory)]
    [FsgImg.Dds.Abstractions.Enums.DdsImgPlatform ]$Platform
)

foreach ($path in $LiteralPath) {
    if (-not $Destination) {
        $Destination = [System.IO.Path]::ChangeExtension($path, [FsgImg.Abstractions.ImgConstants]::ImgExtension)
    }

    $ddsFile = [System.IO.Path]::ChangeExtension($Destination, [FsgImg.Dds.Abstractions.DdsConstants]::DdsExtension)

    # Convert input file to DDS using PVRTexToolCLI
    PVRTexToolCLI -i $path -o $ddsFile $Remaining

    try {
        # Convert DDS file to IMG using FsgImg PowerShell module
        New-FsgImgDds $ddsFile $Destination -Game $Game -Platform $Platform
    }
    finally {
        # Delete intermediate DDS file
        Remove-Item $ddsFile
    }
}
