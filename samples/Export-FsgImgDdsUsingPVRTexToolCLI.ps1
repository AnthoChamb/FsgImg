param(
    [Alias("PSPath", "i")]
    [Parameter(Mandatory, Position = 0, ValueFromPipeline, ValueFromPipelineByPropertyName)]
    [string[]]$LiteralPath,

    [Alias("d")]
    [Parameter(Position = 1)]
    [string]$Destination,

    [Parameter(Position = 2, ValueFromRemainingArguments)]
    [string[]]$Remaining,

    [Parameter()]
    [System.Nullable[FsgImg.Dds.Abstractions.Enums.DdsImgPlatform]]$Platform
)

foreach ($path in $LiteralPath) {
    if (-not $Destination) {
        $Destination = [System.IO.Path]::ChangeExtension($path, '.png')
    }

    $ddsFile = [System.IO.Path]::ChangeExtension($Destination, [FsgImg.Dds.Abstractions.DdsConstants]::DdsExtension)

    # Convert IMG file to DDS using FsgImg PowerShell module
    Export-FsgImgDds $path $ddsFile -Platform $Platform

    try {
        # Convert DDS file to decompressed file using PVRTexToolCLI
        PVRTexToolCLI -i $ddsFile -noout -d $Destination $Remaining
    }
    finally {
        # Delete intermediate DDS file
        Remove-Item $ddsFile
    }
}
