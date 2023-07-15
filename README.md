# Mech3DotNet

This project provides .NET bindings for [MechWarrior 3 Asset Extractor](https://github.com/TerranMechworks/mech3ax) (`mech3ax`).

Obviously, this is an unofficial fan effort and not connected to the developers, publishers, or rightsholders. [Join us on MW3 Discord](https://discord.gg/Be53gMy)!

## Changelog

### [0.6.0-rc5] - Unreleased

### [0.6.0-rc4] - 2023-07-15

* Breaking changes!
* Serialize C# enums as enums, not classes.
* Tracks [mech3ax v0.6.0-rc4](https://github.com/TerranMechworks/mech3ax/releases/tag/v0.6.0-rc4)
* Major rewrite of how types are read and written.
* Documentation.

### [0.6.0-rc3] - Unreleased

* This release was skipped.

### [0.6.0-rc2] - 2022-11-30

* Breaking changes!
* Tracks [mech3ax v0.6.0-rc2](https://github.com/TerranMechworks/mech3ax/releases/tag/v0.6.0-rc2)
* Migrated from System.Text.Json to custom data exchange format - no more dependencies!
* Re-homed all API data types from `Mech3DotNet.Json` to `Mech3DotNet.Types`

### [0.6.0-rc1] - 2022-11-20

* Breaking changes!
* Tracks [mech3ax v0.6.0-rc1](https://github.com/TerranMechworks/mech3ax/releases/tag/v0.6.0-rc1)
* Migrated from Newtonsoft.Json to System.Text.Json
* Auto-generated C# data structures from Rust structures
* Support `anim.zbd` reading and writing
* Faster, native-based reader parsing
* Build-in deserialization of some known reader files

### [0.5.0] - 2022-08-14

* Tracks [mech3ax v0.5.0](https://github.com/TerranMechworks/mech3ax/releases/tag/v0.5.0)

### [0.1.0] - unreleased

* Initial release

## Development

The development SDK is the LTS [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

The main library targets .NET Standard 2.1 for Unity compatibility (`netstandard2.1`). The unit and functional tests target .NET 6.0 (`net6.0`).

Also required are [mech3ax](https://github.com/TerranMechworks/mech3ax/releases/) native dependencies, e.g. for version 0.6.0:

* `mech3ax-0.6.0.dll` (Windows x64)
* `libmech3ax-0.6.0.so` (Linux x64)
* `libmech3ax-0.6.0.dylib` (MacOS x64, or ARM when supported)

Put one or more into the `Mech3DotNet/` directory for testing.

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
1. Commit, push, and wait for CI
1. Create a tag of the version (e.g. `git tag v0.6.0-rc3`)
1. Push the tag (`git push --tags`)
1. The build will automatically create a release as a draft
1. Add changelog items to the release notes via the GitHub web interface
1. Publish the release via the GitHub web interface

## License

Licensed under the European Union Public Licence (EUPL) 1.2 ([LICENSE](LICENSE) or https://joinup.ec.europa.eu/collection/eupl/eupl-text-eupl-12).
