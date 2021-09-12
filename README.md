# Mech3DotNet

This project provides .NET bindings for [MechWarrior 3 Asset Extractor](https://github.com/TerranMechworks/mech3ax) (`mech3ax`).

Obviously, this is an unofficial fan effort and not connected to the developers or publishers. [Join us on Discord](https://discord.gg/Be53gMy)!

## .NET and negative zero floating point values

If you use `Mech3DotNet` targeting .NET Standard 2.0, this is not an issue. If you use `Mech3Dot` targeting the (very old) .NET Framework 2.0, you will not be able to roundtrip negative zero floating point values properly. There is no fix for this.

## Mono and type GUIDs

Certain Mono versions [return zero GUIDs](https://stackoverflow.com/questions/8666514/does-type-guid-uniquely-identifies-each-type-across-compilations) for `Type.GUID`, i.e. the same GUID for different types. The `DiscriminatedUnionConverter` relies on type GUIDs to identify nested classes without having to parse the type's `FullName` when e.g. inherited. You should ensure all nested classes in a `DiscriminatedUnion` type have a GUID specified manually via the `[Guid("")]` attribute for this logic to work in some Mono versions (e.g. Unity).

## Changelog

### [0.1.0] - unreleased

* Initial release

## Development

[Visual Studio 2019 Community Edition](https://visualstudio.microsoft.com/vs/community/) was used to create this project.

The project targets the .NET Framework 2.0 for Unity 5.6.7f1 compatibility.

## License

MechWarrior 3 Asset Extractor and the .NET bindings are GPLv3 licensed. Please see `LICENSE.txt` in this repository and the `mech3ax` repository.
