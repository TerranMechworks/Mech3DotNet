# Changelog

## [unreleased]

## [0.7.0-rc2] - 2025-08-03

* Tracks [mech3ax v0.7.0-rc2](https://github.com/TerranMechworks/mech3ax/releases/tag/v0.7.0-rc2)

## [0.6.1] - 2024-11-28

* Tracks [mech3ax v0.6.1](https://github.com/TerranMechworks/mech3ax/releases/tag/v0.6.1)
* Types: Archive entry info
* Types: GameZ header unk08 to datetime
* Types: Partition z_mid fix for US 1.0/1.1
* Types: global palette index i32 -> u32
* Types: remove reset_state_ptr in AnimDef
* Support u64 in exchange protocol
* Marshal `usize` values properly
* Materials field 32 is soil type

## [0.6.0] - 2024-02-10

* Tracks [mech3ax v0.6.0](https://github.com/TerranMechworks/mech3ax/releases/tag/v0.6.0)

## [0.6.0-rc4] - 2023-07-15

* Breaking changes!
* Serialize C# enums as enums, not classes.
* Tracks [mech3ax v0.6.0-rc4](https://github.com/TerranMechworks/mech3ax/releases/tag/v0.6.0-rc4)
* Major rewrite of how types are read and written.
* Documentation.

## [0.6.0-rc3] - Unreleased

* This release was skipped.

## [0.6.0-rc2] - 2022-11-30

* Breaking changes!
* Tracks [mech3ax v0.6.0-rc2](https://github.com/TerranMechworks/mech3ax/releases/tag/v0.6.0-rc2)
* Migrated from System.Text.Json to custom data exchange format - no more dependencies!
* Re-homed all API data types from `Mech3DotNet.Json` to `Mech3DotNet.Types`

## [0.6.0-rc1] - 2022-11-20

* Breaking changes!
* Tracks [mech3ax v0.6.0-rc1](https://github.com/TerranMechworks/mech3ax/releases/tag/v0.6.0-rc1)
* Migrated from Newtonsoft.Json to System.Text.Json
* Auto-generated C# data structures from Rust structures
* Support `anim.zbd` reading and writing
* Faster, native-based reader parsing
* Build-in deserialization of some known reader files

## [0.5.0] - 2022-08-14

* Tracks [mech3ax v0.5.0](https://github.com/TerranMechworks/mech3ax/releases/tag/v0.5.0)

## [0.1.0] - unreleased

* Initial release
