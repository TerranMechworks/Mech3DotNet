# Mech3DotNet

This project provides .NET bindings for [MechWarrior 3 Asset Extractor](https://github.com/TerranMechworks/mech3ax) (`mech3ax`).

Obviously, this is an unofficial fan effort and not connected to the developers or publishers. [Join us on Discord](https://discord.gg/Be53gMy)!

## Mono and type GUIDs

Certain Mono versions [return zero GUIDs](https://stackoverflow.com/questions/8666514/does-type-guid-uniquely-identifies-each-type-across-compilations) for `Type.GUID`, i.e. the same GUID for different types. The `DiscriminatedUnionConverter` relies on type GUIDs to identify nested classes without having to parse the type's `FullName` when e.g. inherited. You should ensure all nested classes in a `DiscriminatedUnion` type have a GUID specified manually via the `[Guid("")]` attribute for this logic to work in some Mono versions (e.g. Unity).

## Changelog

### [0.1.0] - unreleased

* Initial release

## Development

The development SDK is the LTS [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).

The main library targets .NET Standard 2.1 for Unity compatibility (`netstandard2.1`). The unit and functional tests target .NET 6.0 (`net6.0`).

## License

Licensed under the European Union Public Licence (EUPL) 1.2 ([LICENSE](LICENSE) or https://joinup.ec.europa.eu/collection/eupl/eupl-text-eupl-12).
