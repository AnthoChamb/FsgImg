param(
    [Alias("PSPath", "i")]
    [Parameter(Mandatory, Position = 0, ValueFromPipeline, ValueFromPipelineByPropertyName)]
    [string[]]$LiteralPath,

    [Alias("o")]
    [Parameter(Position = 1)]
    [string]$Destination,

    [Parameter(Position = 2, ValueFromRemainingArguments)]
    [string[]]$Remaining
)

foreach ($path in $LiteralPath) {
    if (-not $Destination) {
        $Destination = [System.IO.Path]::ChangeExtension($path, [FsgImg.Abstractions.ImgConstants]::ImgExtension)
    }

    $pvrFile = [System.IO.Path]::ChangeExtension($Destination, [FsgImg.Pvr.Abstractions.PvrConstants]::PvrExtension)

    # Convert input file to PVR using PVRTexToolCLI
    PVRTexToolCLI -i $path -o $pvrFile $Remaining

    try {
        # Convert PVR file to IMG using FsgImg PowerShell module
        New-FsgImgPvr $pvrFile $Destination
    }
    finally {
        # Delete intermediate PVR file
        Remove-Item $pvrFile
    }
}
