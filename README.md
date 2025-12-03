# FsgImg

[![build status](https://github.com/AnthoChamb/FsgImg/actions/workflows/build.yml/badge.svg)](https://github.com/AnthoChamb/FsgImg/actions/workflows/build.yml)

Work-in-progress .NET class libraries and PowerShell module for managing FSG IMG texture files.

## FsgImg PowerShell module

[![latest version](https://img.shields.io/powershellgallery/v/FsgImg)](https://www.powershellgallery.com/packages/FsgImg) [![downloads](https://img.shields.io/powershellgallery/dt/FsgImg)](https://www.powershellgallery.com/packages/FsgImg)

PowerShell module for FsgImg.

### Installation

FsgImg is available in the [PowerShell Gallery](https://www.powershellgallery.com/packages/FsgImg).

```pwsh
Install-Module FsgImg
```

If you have an earlier version of the FsgImg PowerShell module installed from the PowerShell Gallery and would like to update to the latest version.

```pwsh
Update-Module FsgImg
```

### Usage

The following code demonstrates usage of the FsgImg PowerShell module.

```pwsh
Import-Module FsgImg
Export-FsgImgDds input.img output.dds
New-FsgImgDds input.dds output.img -Platform Xbox360

Export-FsgImgPvr input.img output.pvr
New-FsgImgPvr input.pvr output.img
```

Check out the [samples](samples/) directory for more examples.
