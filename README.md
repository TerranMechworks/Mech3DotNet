# Mech3DotNet

This project provides .NET bindings for [MechWarrior 3 Asset Extractor](https://github.com/TerranMechworks/mech3ax) (`mech3ax`).

Obviously, this is an unofficial fan effort and not connected to the developers, publishers, or rightsholders. [Join us on MW3 Discord](https://discord.gg/Be53gMy)!

## Changelog

See [CHANGELOG](CHANGELOG.md).

## Development

The development SDK is the LTS [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

The main library targets .NET Standard 2.1 for Unity compatibility (`netstandard2.1`). The unit and functional tests target .NET 8.0 (`net8.0`).

Also required are [mech3ax](https://github.com/TerranMechworks/mech3ax/releases/) native dependencies, e.g. for version 0.6.1:

* `mech3ax-v0.6.1.dll` (Windows x64)
* `libmech3ax-v0.6.1.so` (Linux x64)
* `libmech3ax-v0.6.1.dylib` (MacOS x64/ARM)

Put the one for the platform you're running on into the `Mech3DotNet/` directory for testing.

### Unit tests

Simply run `dotnet test`, or for a more verbose output:

```shell
dotnet test --logger "console;verbosity=detailed"
```

### Roundtrip tests

This requires one or more compatible game files. For example, this might be `C:\Program Files (x86)\MechWarrior 3` on Windows. On other platforms, you may have multiple versions for testing in a folder:

```console
$ ls -1 "$HOME/Documents/mw3/"
v1.0-de-patched/
v1.2-us-patched/
```

The tests will recurse into the specified folder, and execute the roundtrip tests for all matching files. So:

```shell
dotnet run --project RoundtripTests "$HOME/Documents/mw3/"
```

will run the tests against both versions.

## Release procedure

1. Review changelog, and add the date
1. Bump version in `Mech3DotNet/Properties/AssemblyInfo.cs` and `RoundtripTests/Properties/AssemblyInfo.cs`
1. Update version in `Mech3DotNet/Mech3DotNet.csproj` so that binaries are copied to the output directory
1. Commit, push, and wait for CI
1. Create a tag of the version (e.g. `git tag -a v0.1.0 -m "2024-02-10" -s`)
1. Push the tag (`git push origin v0.1.0`)
1. The build will automatically create a release as a draft
1. Add changelog items to the release notes via the GitHub web interface
1. Publish the release via the GitHub web interface

## License

Licensed under the European Union Public Licence (EUPL) 1.2 ([LICENSE](LICENSE) or https://joinup.ec.europa.eu/collection/eupl/eupl-text-eupl-12).
