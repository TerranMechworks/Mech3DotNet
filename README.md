# Mech3DotNet

This project provides .NET bindings for [MechWarrior 3 Asset Extractor](https://github.com/TerranMechworks/mech3ax) (`mech3ax`).

Obviously, this is an unofficial fan effort and not connected to the developers or publishers. [Join us on Discord](https://discord.gg/Be53gMy)!

## .NET and negative zero floating point values

IEEE Standard for Floating-Point Arithmetic (IEEE 754) specifies signed zero values for both single and double precision numbers (although `mech3ax` is largely concerned with single precision). For all floating point numbers in the base game, `mech3ax` and the JSON serialization/deserialization it employs correctly round-trip those values. However, .NET does not correctly round-trip negative zero until [.NET Core 3.0](https://devblogs.microsoft.com/dotnet/floating-point-parsing-and-formatting-improvements-in-net-core-3-0/), in violation of IEEE 754/the JSON specification. When JSON is parsed or emitted, negative zero becomes positive zero. Negative zero has a different bit pattern than positive zero. Therefore, if you need bit accurate round-tripping, you must use the `NegativeZeroFloatConverter`, and the corresponding `PreDeserializeHook` (`EncodeNegativeZero`) and `PostSerializeHook` (`DecodeNegativeZero`) to preserve single precision negative zero values.

In short, `EncodeNegativeZero` replaces only negative zero (`-0.0`, not e.g. `-0.01`) with a string-quoted value (`"-0.0"`) before the JSON is deserialized. Then, `NegativeZeroFloatConverter` is able to parse this into the correct `float` representation. Equally, `NegativeZeroFloatConverter` serializes only negative zero to `"-0.0"`, which is then replaced with `-0.0`. This is a nasty hack, but seems to work so far.

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
