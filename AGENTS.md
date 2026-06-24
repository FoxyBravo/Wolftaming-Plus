# WolfTaming Mod — Project Knowledge

## Build
- Project: `WolfTaming\WolfTaming.csproj`
- Framework: `net10.0`
- Build command: `dotnet build -c Release` (run from `WolfTaming\` directory)
- Output: `WolfTaming\bin\Release\Mods\mod\`

## Deploy
The game loads mods from **`%appdata%\VintagestoryData\Mods\`**, NOT `%appdata%\Vintagestory\Mods\`.

Deploy steps:
1. `dotnet build -c Release` in `WolfTaming\`
2. Delete old version folder: `Remove-Item "%appdata%\VintagestoryData\Mods\wolftaming-vX.Y.Z" -Recurse -Force`
3. Copy build output: `robocopy "WolfTaming\bin\Release\Mods\mod" "%appdata%\VintagestoryData\Mods\wolftaming-vX.Y.Z" /E /IS`

The folder name includes the version (e.g., `wolftaming-v5.0.26`). Use `robocopy` instead of `Copy-Item` for reliable file copying.

## Version
- Update in `WolfTaming\modinfo.json` before building
- Keep folder name in sync with version

## Key Files
- `WolfTaming\src\Wolftaming.cs` — mod system, registers AI tasks
- `WolfTaming\src\Entity\AITask\AiTaskPlayFetch.cs` — dog fetch AI, has `DogToy` property (EntityItem) that petai sets via reflection
- `WolfTaming\src\Entity\AITask\AiTaskStayCloseToShepherd.cs` — shepherd task
- `WolfTaming\assets\wolftaming\itemtypes\dogtoy.json` — chewing bone (uses vanilla `Item` class + petai `PetAIChewingBoneAimThrow` behavior, not a custom class)
- `WolfTaming\assets\wolftaming\itemtypes\creatures.json` — dog variant definitions

## Dependencies on petai
- wolftaming depends on `petai: 5.0.0` (see `modinfo.json`)
- The `dogtoy` item references `PetAIChewingBoneAimThrow` (a CollectibleBehavior in petai). That behavior, in turn, uses reflection to find `WolfTaming.AiTaskPlayFetch` and set its `DogToy` property so the dog can fetch the thrown bone.
- Do NOT add a custom `ItemDogToy` class — the chewing bone uses vanilla `Item` and the petai behavior chain. Adding a duplicate class breaks the chain.

## Known Issues / Investigations
- The user previously worked in an unzipped `wolftaming_v5.0.1` folder that had been accidentally `git init`'d by an opencode session, with a bogus `feature/petai-aim-throw` branch. That folder has been removed. The real source is `wolftaming-source\` (this repo).
- `core.autocrlf=true` is the system default on Windows. Most "modified" JSON files between the user's old zip and the source were just line-ending differences and don't show as actual git changes. Use `git diff --name-only` to see real content changes.
