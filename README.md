# Pixeler.Net
A port of [Pixeler](https://github.com/RyukASF/Pixeler), originally developed by [Ryuk](https://github.com/RyukASF).
This implementation uses C# and Windows Forms for a GUI.


## Table of Contents
1. [Using Pixeler.Net](./docs/README.md)
2. [Build Instructions](#build-instructions)
   1. [Building with Make](#building-pixelernet-with-make)
   2. [Building without make](#building-pixelernet-without-make)


# Build Instructions

## Cloning The Repository

To clone the repo, run this command

```ps
$ git clone https://github.com/ScripturaOpus/Pixeler.Net.git
```

## Building Pixeler.Net (With make)

To make Pixeler.Net, run `make` from the projects root directory.

```ps
$ make
```
This will automatically build Pixeler.Net for Windows using the same architecture
as your machine.
If you want to specify another architecture, append a dash and then your wanted architecture.

```ps
$ make build-x86
```

## Building Pixeler.Net (Without make)

If you're using Windows, then run
```ps
$ powershell ./build.ps1
```

If you're on Linux, then run
```ps
$ bash ./build.sh
```

> [!IMPORTANT]  
> Note: This will ***NOT*** build Pixeler.Net for Linux.
> It will build Pixeler.Net *ON* Linux (Still targeting Windows)

This will automatically build Pixeler.Net for Windows using the same architecture
as your machine.
If you want to specify another architecture, append `win-` and then your wanted architecture.

```ps
$ powershell build.ps1 win-x86
```

The same can be done to force an x64 build

```ps
$ bash build.sh win-x64
```