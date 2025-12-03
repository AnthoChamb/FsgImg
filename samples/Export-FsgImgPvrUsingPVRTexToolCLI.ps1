param(
    [Alias("PSPath", "i")]
    [Parameter(Mandatory, Position = 0, ValueFromPipeline, ValueFromPipelineByPropertyName)]
    [string[]]$LiteralPath,

    [Alias("d")]
    [Parameter(Position = 1)]
    [string]$Destination,

    [Parameter(Position = 2, ValueFromRemainingArguments)]
    [string[]]$Remaining
)

foreach ($path in $LiteralPath) {
    if (-not $Destination) {
        $Destination = [System.IO.Path]::ChangeExtension($path, '.png')
    }

    $pvrFile = [System.IO.Path]::ChangeExtension($Destination, [FsgImg.Pvr.Abstractions.PvrConstants]::PvrExtension)

    # Convert IMG file to PVR using FsgImg PowerShell module
    Export-FsgImgPvr $path $pvrFile

    try {
        # Convert PVR file to decompressed file using PVRTexToolCLI
        PVRTexToolCLI -i $pvrFile -noout -d $Destination $Remaining
    }
    finally {
        # Delete intermediate PVR file
        Remove-Item $pvrFile
    }
}
