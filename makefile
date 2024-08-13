.PHONY: build

# Auto detect OS type
BuildFile :=
ifeq ($(OS),Windows_NT)
	BuildFile += powershell ./build.ps1
else
# Note: This will NOT build Pixeler.Net for Linux
# It will build Pixeler.Net ON Linux (Still targeting Windows)
	BuildFile += bash ./build.sh
endif

build:
	$(BuildFile)

build-x64:
	$(BuildFile) -r win-x64

build-x86:
	$(BuildFile) -r win-x86